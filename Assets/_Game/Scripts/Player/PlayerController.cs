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

    private bool canMove;

    private Vector3 direction;

    private Vector3 posNextBlock;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startPos.position.x, transform.position.y, startPos.position.z);
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                        if(!block.IsHighLight && block.IsPredition)
                        {
                            hit.transform.gameObject.GetComponent<Block>().ActiveHightLighBlock();
                            Vector3 target = new Vector3(hit.transform.position.x,transform.position.y,hit.transform.position.z);
                            direction = target - transform.position;
                            posNextBlock = target;
                            canMove = true;
                        }
                    }

                }
            }
        }
        if(canMove)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            Vector3 dis = (transform.position - posNextBlock);
            float distance = dis.magnitude;
            if (distance < 0.1f)
            {
                canMove = false;
            }
        }
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
