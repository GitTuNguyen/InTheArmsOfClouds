using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform startPos;

    [SerializeField]
    private LayerMask layerMask;



    [SerializeField]
    private GameObject playerGhost;

    [SerializeField]
    private List<Vector3> path;

    [SerializeField]
    private LineRenderer line;

    [SerializeField]
    private GameObject smallCircle;

    [SerializeField]
    private GameObject bigCircle;

    int currentIndex = 0;
    int nextIndex = 1;

    private int leghtOfLineRender;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startPos.position.x, transform.position.y, startPos.position.z);
        path = new List<Vector3>();
        leghtOfLineRender = 1;
        path.Add(bigCircle.transform.position);
        line.SetPosition(0, bigCircle.transform.position);
        smallCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerSelectPath()
    {
        Vector3 direction = Vector3.zero;

        Vector3 posNextBlock = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            {
                if (Physics.Raycast(ray, out hit, layerMask))
                {
                    Debug.DrawLine(transform.position, hit.point);

                    Block block = hit.transform.gameObject.GetComponent<Block>();

                    if (block != null)
                    {
                        if (!block.IsHighLight && block.IsPredition)
                        {
                            hit.transform.gameObject.GetComponent<Block>().ActiveHightLighBlock();

                            Vector3 target = new Vector3(hit.transform.position.x, bigCircle.transform.position.y, hit.transform.position.z);
                            direction = target - playerGhost.transform.position;
                            posNextBlock = target;
                            playerGhost.transform.position = posNextBlock;
                            path.Add(target);
                            leghtOfLineRender += 1;
                            smallCircle.SetActive(true);
                            smallCircle.transform.position = posNextBlock;
                            line.positionCount = leghtOfLineRender;
                            line.SetPosition(leghtOfLineRender - 1, posNextBlock);
                        }
                    }

                }
            }
        }

    }
    public bool PlayerFollowPath()
    {
        if (nextIndex <= leghtOfLineRender - 1)
        {
            Vector3 currentPos = path[currentIndex];
            Vector3 nextPos = path[nextIndex];
            Vector3 dir = nextPos - currentPos;
            transform.Translate(dir.normalized * speed * Time.deltaTime);
            Vector3 dis = (bigCircle.transform.position - nextPos);
            float distance = dis.magnitude;
            if (distance < 0.1f)
            {
                currentIndex += 1;
                nextIndex += 1;
            }
            return true;
        }
        else
        {
            return false;
        }

    }

    public void StartFollowPath()
    {
        smallCircle.SetActive(false);
        playerGhost.SetActive(false);
    }
    public void PlayerEndTurn()
    {
        playerGhost.SetActive(true);
        playerGhost.transform.position = transform.position;

        leghtOfLineRender = 1;
        path.Clear();
        path.Add(bigCircle.transform.position);
        line.positionCount = 1;
        line.SetPosition(0, bigCircle.transform.position);
        smallCircle.SetActive(false);

        currentIndex = 0;
        nextIndex = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            Block block = other.gameObject.GetComponent<Block>();
            if(block != null)
            {
                block.ActivePreditionBlock();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Block block = other.gameObject.GetComponent<Block>();
            if (block != null)
            {
                block.ResetBlock();
            }
        }
    }
}
