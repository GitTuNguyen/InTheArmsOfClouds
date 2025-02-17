using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItemData itemData;
    [SerializeField] public int stackSize;
    public InventoryItemData ItemData => itemData;
    public int StackSize
    {
        get => stackSize;
        set 
        {
            stackSize = value;
        }
    }

    public InventorySlot(InventoryItemData source, int amount){
        itemData = source;
        stackSize = amount;
    }

    public InventorySlot(){
        ClearSLot();
    }

    public void ClearSLot(){
        itemData = null;
        stackSize = -1;
    }

    public void UpdateInventorySlot(InventoryItemData data, int amount){
        itemData = data;
        stackSize = amount;
    }
    public bool RoomLeftInStack(int amountToAdd, out int amountRemaining){
        amountRemaining = ItemData.maxStackSize - stackSize;
        return RoomLeftInStack(amountToAdd);
    }

    public bool RoomLeftInStack(int amountToAdd){
        if(stackSize + amountToAdd <= itemData.maxStackSize)
            return true;
        else
        {
            return false;
        }

    }

    public void AddToStack(int amount){
        stackSize += amount;
    }

    public void RemoveFromStack(int amount){
        stackSize -= amount;
        if(stackSize <= 0)
        {
            itemData = null;
        }
    }
}
