using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private GameObject posStartBlock;


    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private GameObject cloudsMachine;

    private bool canRenoveCloud;

    private void OnEnable()
    {
        EventManager.UseAmuletItem += RemoveCloundOnTheMap;
    }

    private void OnDisable()
    {
        EventManager.UseAmuletItem -= RemoveCloundOnTheMap;
    }

    // Start is called before the first frame update
    void Start()
    {
        canRenoveCloud = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRenoveCloud)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitTarget;

                Ray rayTarget = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(rayTarget, out hitTarget, Mathf.Infinity, layerMask))
                {
                    Block block = hitTarget.transform.gameObject.GetComponent<Block>();


                    if (block != null && block.CheckCloudOfBlock())
                    {
                        canRenoveCloud = false;
                        
                        cloudsMachine.SetActive(false);

                        // Remove clound
                        cloudsMachine.GetComponent<CloudMachine>().RemoveCouldOfListBlock();

                        EventManager.EndOfTurnUseItem?.Invoke();

                    }
                }
            }

            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Block block = hit.transform.gameObject.GetComponent<Block>();

                Vector3 pos = block.transform.position;

                if (block != null && block.CheckCloudOfBlock())
                {
                    cloudsMachine.transform.position = new Vector3(pos.x, pos.y + 1.5f, pos.z);
                }
            }

        }
    }

    private void RemoveCloundOnTheMap()
    {
        canRenoveCloud = true;
        cloudsMachine.SetActive(true);
        Debug.Log("Remove cloud on the map");
    }
}
