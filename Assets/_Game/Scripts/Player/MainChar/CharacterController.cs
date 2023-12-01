using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private GameObject playerGhost;

    [SerializeField]
    private List<Vector3> path;

    private List<GameObject> blocks;

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

    [SerializeField]
    private GameObject tomb;

    bool isFacingRight;

    int currentIndex = 0;
    int nextIndex = 1;

    private int leghtOfLineRender;

    private CapsuleCollider capsuleCollider;

    private Vector3 posSmallCircle;

    public int numberDice;

    private bool isSelectedFirstBlock;
    private Vector3 startPos;
    private Vector3 currentPos;

    public Block targetBlock;

    private void OnEnable()
    {
        EventManager.PlayerDie += RessetPlayerController;
    }

    private void OnDisable()
    {
        EventManager.PlayerDie -= RessetPlayerController;
    }

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        posSmallCircle = smallCircle.transform.localPosition;
        isFacingRight = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        path = new List<Vector3>();
        leghtOfLineRender = 1;
        path.Add(bigCircle.transform.position);
        line.SetPosition(0, bigCircle.transform.position);
        blocks = new List<GameObject>();
        isSelectedFirstBlock = false;
        numberDice = 0;
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

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawLine(transform.position, hit.point);

                Block block = hit.transform.gameObject.GetComponent<Block>();

                if (block != null && numberDice > 0)
                {
                    if (block.IsHighLight)
                    {
                        if (!isSelectedFirstBlock)
                        {
                            if (block.CheckCloudOfBlock())
                            {
                                line.SetPosition(0, new Vector3(bigCircle.transform.position.x, bigCircle.transform.position.y + 0.8f, bigCircle.transform.position.z));
                            }
                        }
                        isSelectedFirstBlock = true;
                        Vector3 target = new Vector3(hit.transform.position.x, bigCircle.transform.position.y, hit.transform.position.z);
                        direction = target - playerGhost.transform.position;
                        posNextBlock = target;
                        Vector3 nextPos = Vector3.zero;
                        if (block.CheckCloudOfBlock())
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
                        block.IsSelected = true;
                        blocks.Add(block.gameObject);
                        numberDice--;
                        Debug.Log("numberDice run = " + numberDice);
                        SFXManager.Instance?.PlaySound("FindPath");
                        EventManager.SelectBlockOnTheMap?.Invoke(numberDice);
                    }
                }

            }
        }

    }

    private void FlipPlayer()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
    public bool PlayerFollowPath()
    {
        if (nextIndex <= leghtOfLineRender - 1)
        {
            Vector3 currentPos = path[currentIndex];
            Vector3 nextPos = path[nextIndex];
            Vector3 dir = nextPos - currentPos;
            if(dir.x < 0 && isFacingRight)
            {
                FlipPlayer();
            }

            if (dir.x >= 0 && !isFacingRight)
            {
                FlipPlayer();
            }
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

    public void StartSelectPath()
    {
        playerGhost.SetActive(true);
        capsuleCollider.enabled = false;
        smallCircle.SetActive(true);
        smallCircle.transform.localPosition = posSmallCircle;
        numberDice = GameManager.Instance.currentDiceNumber;
    }

    public void StartFollowPath()
    {
        character.SetBool("isIdle", false);
        character.SetBool("isRun", true);
        smallCircle.SetActive(false);
        playerGhost.SetActive(false);
        capsuleCollider.enabled = true;
    }
    public void PlayerEndTurn()
    {
        character.SetBool("isIdle", true);
        character.SetBool("isRun", false);

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
        Debug.Log("numberDice = " + numberDice);
        numberDice = 0;
        playerUI.DisableUICanvas();
        foreach (GameObject block in blocks)
        {
            if (block.GetComponent<Block>() != null)
            {
                block.GetComponent<Block>().IsSelected = false;
            }
        }

        blocks.Clear();

        isSelectedFirstBlock = false;
        currentPos = transform.position;
    }
    public bool PlayerCanMove()
    {
        return numberDice == 0;
    }
    public void PlayerTriggerEvent()
    {
        targetBlock = blocks[blocks.Count - 1].GetComponent<Block>();
        if (targetBlock != null)
        {
            targetBlock.TriggerEvent();
        }
    }

    public void RessetPlayerController()
    {
        // Check Inventory has Item Enchanted Stew
        GameObject tombObj = Instantiate(tomb, transform.position, Quaternion.identity);
        InventoryItemData itemData = InventoryHolder.Instance.InventorySystem.GetItemByItemType(ItemType.EnchantedStew);
        Debug.Log("RessetPlayerController: itemData == null? " + itemData == null);
        if (InventoryHolder.Instance.InventorySystem.ContainsItem(itemData, out List<InventorySlot> invSlot))
        {
           InventoryHolder.Instance.InventorySystem.RemoveToInventory(itemData, 1);
        }
        else
        {
            InventoryHolder.Instance?.InventorySystem.ClearInventory();
           transform.position = new Vector3(startPos.x, startPos.y, startPos.z);
        }

        PlayerEndTurn();
    }

    public void PlayerRollDice()
    {
        numberDice = Random.Range(1, 7);
        GameManager.Instance.currentDiceNumber = numberDice;
        Debug.Log("current dice = " + numberDice);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Block")
        {
            Block block = other.gameObject.GetComponent<Block>();
            if (block != null)
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
