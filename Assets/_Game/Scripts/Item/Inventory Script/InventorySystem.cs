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
    public int InventorySize => InventorySlot.Count;

    public UnityAction<InventorySlot> OnInventorySlotChanged;

    [SerializeField]
    private List<InventorySlotUI> inventorySlotUIs;

    public void InitInventorySystem(int size){
        inventorySlots = new List<InventorySlot>(size);
        for(int i = 0; i< size ; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }

        //inventorySlotUIs = new List<InventorySlotUI>(size);
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd){
        if(ContainsItem(itemToAdd, out List<InventorySlot> invSlot))//Check whether item is exist in inventory
        {
            foreach(var slot in invSlot)
            {
                if(slot.RoomLeftInStack(amountToAdd)){
                    slot.AddToStack(amountToAdd);
                    inventorySlotUIs[inventorySlots.IndexOf(slot)].UpdateInventorySlot(slot.ItemData, slot.StackSize);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }

        if(HasFreeSlot(out InventorySlot freeSlot))//Get first available slot
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            inventorySlotUIs[inventorySlots.IndexOf(freeSlot)].UpdateInventorySlot(itemToAdd,amountToAdd);          
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }

        return false;
    }

    public bool RemoveToInventory(InventoryItemData itemToRemove, int amountToRemove,InventorySlotUI slotUI){
        if(ContainsItem(itemToRemove, out List<InventorySlot> invSlot))
        {
            InventorySlot slot = inventorySlots[inventorySlotUIs.IndexOf(slotUI)];
            slot.RemoveFromStack(amountToRemove);
            inventorySlotUIs[inventorySlotUIs.IndexOf(slotUI)].UpdateInventorySlot(itemToRemove, slot.StackSize);
            return true;

        }
        return false;
    }

    public bool ContainsItem(InventoryItemData itemtoAdd, out List<InventorySlot> invSlot){
        invSlot = InventorySlot.Where(i => i.ItemData == itemtoAdd).ToList();
        return invSlot == null ? false: true;
    }

    public bool HasFreeSlot(out InventorySlot freeSlot){
        freeSlot = InventorySlot.FirstOrDefault(i => i.ItemData == null);
        return freeSlot == null ? false: true;
    }
}
