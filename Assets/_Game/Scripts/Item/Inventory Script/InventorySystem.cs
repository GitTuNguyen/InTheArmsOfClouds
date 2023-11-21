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
    public InventorySystem(int size){
        inventorySlots = new List<InventorySlot>(size);
        for(int i = 0; i< size ; i++)
        {
            inventorySlots.Add(new InventorySlot());
        }
    }

    public bool AddToInventory(InventoryItemData itemToAdd, int amountToAdd){
        if(ContainsItem(itemToAdd, out List<InventorySlot> invSlot))//Check whether item is exist in inventory
        {
            foreach(var slot in invSlot)
            {
                if(slot.RoomLeftInStack(amountToAdd)){
                    slot.AddToStack(amountToAdd);
                    OnInventorySlotChanged?.Invoke(slot);
                    return true;
                }
            }
        }

        if(HasFreeSlot(out InventorySlot freeSlot))//Get first available slot
        {
            freeSlot.UpdateInventorySlot(itemToAdd, amountToAdd);
            OnInventorySlotChanged?.Invoke(freeSlot);
            return true;
        }

        return false;
    }

    public bool RemoveToInventory(InventoryItemData itemToRemove, int amountToRemove){
        if(ContainsItem(itemToRemove, out List<InventorySlot> invSlot))
        {
            foreach(var slot in invSlot)
            {
                int amountRemaining = 0;
                if(slot.RoomLeftInStack(amountToRemove, out amountRemaining)){
                    if(amountToRemove <= amountRemaining){
                        slot.RemoveFromStack(amountToRemove);
                        OnInventorySlotChanged?.Invoke(slot);
                        return true;
                    } else{
                        Debug.Log("amount To Remove > amount Remaining ");
                        return false;
                    }
                }
            }
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
