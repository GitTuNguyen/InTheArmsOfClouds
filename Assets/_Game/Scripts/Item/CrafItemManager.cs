using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafItemManager : MonoBehaviour
{
    public InventoryCraftableItem inventoryCraftableItem;
    public List<RecipeItem> materialList;

    public bool IsCraftableItem(InventoryCraftableItem craftableItem){
        foreach(RecipeItem material in craftableItem.materialList){
            if(InventoryHolder.Instance.InventorySystem.GetAmountItemInInventory(material.item) < material.required) 
                return false;         
            }
        return true;
    }

    public void CraftableItem(InventoryCraftableItem craftableItem){
        
        if(IsCraftableItem(craftableItem)){
            foreach(RecipeItem material in materialList){
            InventoryHolder.Instance.InventorySystem.RemoveToInventory(material.item, material.required);
            }
            InventoryHolder.Instance.InventorySystem.AddToInventory(craftableItem.crafItem, 1);
        }
    }
}
