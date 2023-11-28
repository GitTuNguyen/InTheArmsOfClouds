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
        InitInventorySlot();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitInventorySlot()
    {
        for(int i = 0; i < InventoryHolder.Instance?.InventorySystem.InventorySlot.Count; i++)
        {
            Instantiate(ItemSlotPrefab, transform);
        }
    }

    public void AddToInventory(InventorySlot item, int index)
    {
        InventoryItemUI inventoryItemUI = transform.GetChild(index)?.GetComponent<InventoryItemUI>();
        if (inventoryItemUI != null)
        {
            inventoryItemUI.SetItemData(item);
        }
    }

    public void RefreshInventoryUI()
    {
        for(int i = 0; i < InventoryHolder.Instance?.InventorySystem.InventorySlot.Count; i++)
        {
            InventoryItemUI inventoryItemUI = transform.GetChild(i)?.GetComponent<InventoryItemUI>();
            if (inventoryItemUI != null && InventoryHolder.Instance?.InventorySystem.InventorySlot[i].ItemData != null)
            {
                inventoryItemUI.SetItemData(InventoryHolder.Instance.InventorySystem.InventorySlot[i]);
            }
        }
    }
}
