using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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

    [SerializeField]
    private Animator character;

    [SerializeField]
    public PlayerUI playerUI;

    int currentIndex = 0;
    int nextIndex = 1;

    private int leghtOfLineRender;

    private CapsuleCollider capsuleCollider;

    private Vector3 posSmallCircle;

    public int numberDice;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        posSmallCircle = smallCircle.transform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startPos.position.x, transform.position.y, startPos.position.z);
        path = new List<Vector3>();
        leghtOfLineRender = 1;
        path.Add(bigCircle.transform.position);
        line.SetPosition(0, bigCircle.transform.position);

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

            if (Physics.Raycast(ray, out hit,Mathf.Infinity, layerMask))
            {
                Debug.DrawLine(transform.position, hit.point);

                Block block = hit.transform.gameObject.GetComponent<Block>();

                if (block != null && numberDice > 0)
                {
                    if (block.IsHighLight)
                    {
                        Vector3 target = new Vector3(hit.transform.position.x, bigCircle.transform.position.y, hit.transform.position.z);
                        direction = target - playerGhost.transform.position;
                        posNextBlock = target;
                        Vector3 nextPos = Vector3.zero;
                        if(block.CheckCloudOfBlock())
                        {
                            nextPos = new Vector3(target.x, target.y + 0.8f, target.z);
                        }
                        else
                        {
                            nextPos = target;
                        }   
                        playerGhost.transform.position = posNextBlock;
                        path.Add(posNextBlock);
                        leghtOfLineRender += 1;
                        smallCircle.transform.position = nextPos;
                        line.positionCount = leghtOfLineRender;
                        line.SetPosition(leghtOfLineRender - 1, nextPos);
                        numberDice--;
                        EventManager.SelectBlockOnTheMap?.Invoke(numberDice);
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


            character.SetBool("isIdle", false);
            character.SetBool("isRight", false);
            character.SetBool("isForward", false);
            character.SetBool("isLeft", false);
            character.SetBool("isBack", false);
            if (dir.normalized.z > 0.8f)
            {
                character.SetBool("isRight", true);
            }
            else if(dir.normalized.x > 0.8f)
            {
                character.SetBool("isBack", true);
            }
            else if(dir.normalized.z < -0.8f)
            {
                character.SetBool("isLeft", true);
            }
            else if(dir.normalized.x < -0.8f)
            {
                character.SetBool("isForward", true);
            }

            if (distance < 0.1f)
            {
                currentIndex += 1;
                nextIndex += 1;
            }
            return true;
        }
        else
        {
            character.SetBool("isRight", false);
            character.SetBool("isForward", false);
            character.SetBool("isLeft", false);
            character.SetBool("isBack", false);
            character.SetBool("isIdle", true);
            return false;
        }

    }

    public void StartSelectPath()
    {
        playerGhost.SetActive(true);
        capsuleCollider.enabled = false;
        smallCircle.SetActive(true);
        smallCircle.transform.localPosition = posSmallCircle;
    }

    public void StartFollowPath()
    {
        smallCircle.SetActive(false);
        playerGhost.SetActive(false);
        capsuleCollider.enabled = true;
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
        numberDice = 0;
        playerUI.DisableUICanvas();
    }

    public void PlayerRollDice()
    {
        numberDice = Random.Range(1, 7);
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
