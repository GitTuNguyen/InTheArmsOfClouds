using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject ItemSlotPrefab;
    public InventorySystem inventorySystem;
    public List<InventoryItemData> inventoryItemDatas;
    public int inventorySlotAmount = 4;

    // Start is called before the first frame update
    void Start()
    {
        inventorySystem = FindObjectOfType<InventoryHolder>()?.InventorySystem;
        InitInventorySlot();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitInventorySlot()
    {
        for(int i = 0; i < inventorySlotAmount && transform.childCount < inventorySlotAmount; i++)
        {
            Instantiate(ItemSlotPrefab, transform);
        }
    }

    public void AddItem(InventoryItemData item, int index)
    {
        InventoryItemUI inventoryItemUI = transform.GetChild(index)?.GetComponent<InventoryItemUI>();
        if (inventoryItemUI != null)
        {
            inventoryItemUI.SetItemData(item);
        }
    }


    

}
