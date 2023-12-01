using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class InventorySystem
{
    [SerializeField] private List<InventorySlot> inventorySlots;
    public List<InventorySlot> InventorySlot => inventorySlots;

    public List<InventoryItemData> items;
    public int InventorySize => InventorySlot.Count;

    //public UnityAction<InventorySlot> OnInventorySlotChanged;

    [SerializeField]
    private List<InventorySlotUI> inventorySlotUIs;
    public int spaceShipPiece = 0;
    public int SpaceShipPieceMax = 4;

    private void OnEnable()
    {
        EventManager. PlayerDie += ResetInventory;
    }

    private void OnDisable()
    {
        EventManager.PlayerDie -= ResetInventory;
    }
    public void InitInventorySystem(int size){
        inventorySlots = new List<InventorySlot>(size);
        for(int i = 0; i< size ; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }

        //inventorySlotUIs = new List<InventorySlotUI>(size);
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd){
        Debug.Log("AddToInventory");
        if(ContainsItem(itemToAdd, out List<InventorySlot> invSlot))//Check whether item is exist in inventory
        {
            foreach(var slot in invSlot)
            {
                if(slot.RoomLeftInStack(amountToAdd)){
                    slot.AddToStack(amountToAdd);

                    ActionPhaseUIManager.Instance.AddToInventory(slot, inventorySlots.IndexOf(slot));
                    //OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }
        Debug.Log("AddToInventory");
        if(HasFreeSlot(out InventorySlot freeSlot))//Get first available slot
        {
            Debug.Log("HasFreeSlot");
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            ActionPhaseUIManager.Instance.AddToInventory(freeSlot, inventorySlots.IndexOf(freeSlot));
            //OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }
         Debug.Log("Has No FreeSlot");
        return false;
    }

    public void RemoveToInventory(InventoryItemData itemToRemove, int amountToRemove){
        if(ContainsItem(itemToRemove, out List<InventorySlot> invSlot))
        {            
            foreach(var slot in invSlot)
            {
                int amountRemaining = 0;
                if (slot.StackSize > amountToRemove)
                {
                    Debug.Log("slot.StackSize > amountToRemove, amountToRemove :  " + amountToRemove);
                    slot.RemoveFromStack(amountToRemove);
                }
                else {                    
                    amountRemaining = amountToRemove - slot.StackSize;
                    Debug.Log("slot.StackSize < amountToRemove, amountRemaining: " + amountRemaining);
                    slot.ClearSLot();
                }

                if (amountRemaining > 0)
                {
                    amountToRemove = amountRemaining;          
                } else {
                    break;
                }
            }
            ActionPhaseUIManager.Instance.RefreshInventoryUI();
        }    
    }

    public void RemoveToInventory(InventoryItemData itemToRemove, int amountToRemove,InventorySlotUI slotUI){
        if(ContainsItem(itemToRemove, out List<InventorySlot> invSlot))
        {            
            foreach(var slot in invSlot)
            {
                int amountRemaining = 0;
                if (slot.StackSize > amountToRemove)
                {
                    Debug.Log("slot.StackSize > amountToRemove, amountToRemove :  " + amountToRemove);
                    slot.RemoveFromStack(amountToRemove);
                    inventorySlotUIs[inventorySlotUIs.IndexOf(slotUI)].UpdateInventorySlot(itemToRemove, slot.StackSize);
                }
                else {                    
                    amountRemaining = amountToRemove - slot.StackSize;
                    Debug.Log("slot.StackSize < amountToRemove, amountRemaining: " + amountRemaining);
                    slot.ClearSLot();
                    inventorySlotUIs[inventorySlotUIs.IndexOf(slotUI)].UpdateInventorySlot(itemToRemove, slot.StackSize);
                }

                if (amountRemaining > 0)
                {
                    amountToRemove = amountRemaining;          
                } else {
                    break;
                }
            }
        }    
    }
    
    public void RemoveFromInventory(int index){
        Debug.Log("clear slot " + index);
        inventorySlots[index].ClearSLot();
    }
    
    public bool AddSpaceShip(){
        if(spaceShipPiece < SpaceShipPieceMax){
            spaceShipPiece += 1;
            Debug.Log(" Space ship piece = " + spaceShipPiece);
            return true;
        }else {
            Debug.Log("Game Finished");
            GameManager.Instance?.GameFinished();
            return false;
        }
    }
    public bool ContainsItem(InventoryItemData itemtoAdd, out List<InventorySlot> invSlot){
        Debug.Log("Check constains Item" + itemtoAdd.nameItem);
        invSlot = InventorySlot.Where(i => i.ItemData == itemtoAdd).ToList();
        return invSlot.Count > 0 ? true : false;
    }

    public int GetAmountItemInInventory(InventoryItemData item){
        var invSlot = InventorySlot.Where(i => i.ItemData == item).ToList();
        int countItem = 0;
        foreach (var slot in invSlot)
        {
            countItem += slot.StackSize;
        }
        return countItem;
    }

    public bool IsItemHasEnoughQuanity(ItemType item, int amount){  // ninh.nghiemthanh: change param type 
        InventoryItemData itemData = GetItemByItemType(item);
        return GetAmountItemInInventory(itemData) >= amount ? true : false;
    }
	
    public bool HasFreeSlot(out InventorySlot freeSlot){
        freeSlot = InventorySlot.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false: true;
    }

    private void UseItemInInventory(InventoryItemData itemData)
    {
        // Player.UpdateStatsOfPlayer(iteamData.heatlh, iteamData.luck,iteamData.santity);

        //RemoveToInventory(itemData, 1);

        switch (itemData.type)
        {
            case ItemType.Amulet:
                EventManager.UseAmuletItem?.Invoke();
                break;
            case ItemType.Shield:
                EventManager.UseEnchantedStewItem?.Invoke();
                break;
            case ItemType.EnchantedStew:

                break;
        }

    }

    public InventoryItemData GetItemByItemType(ItemType type)
    {
        Debug.Log("GetItemByItemType " + type);
        foreach(InventoryItemData item in items)
        {
            if(item.type == type)
            {
                return item;
            }
        }
        return null;
    }

    public void ClearInventory()
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            slot.ClearSLot();
        }
    }

    public void UsingItemAtSlot(int index, InventoryItemData itemUsed = null)
    {
        Debug.Log("using item at " + index);
        InventoryItemData itemData;
        if (itemUsed != null)
        {
            itemData = itemUsed;
        } else {
            itemData = inventorySlots[index].ItemData;
        }
        switch (itemData.type)
        {
            case ItemType.EnchantedStew:
                break;                
            case ItemType.Shield:                
                return;                
            case ItemType.Amulet:
                EventManager.UseAmuletItem?.Invoke();
                break;              
            
            default:
                GameManager.Instance.player.UpdateStatsOfPlayer(itemData.healthItem, itemData.luckItem, itemData.sanityItem);
                break;
        }
        if (itemUsed == null)
        {
            inventorySlots[index].stackSize -= 1;
            if (inventorySlots[index].stackSize <= 0)
            {
                inventorySlots[index].ClearSLot();
            }
        }
        ActionPhaseUIManager.Instance?.RefreshInventoryUI();
    }

    public void ResetInventory()
    {
        Debug.Log("Reset Inventory");
        foreach(InventorySlot slot in inventorySlots)
        {
            if (slot.ItemData != null)
            {
                slot.ClearSLot();
            }
        }
    }
}