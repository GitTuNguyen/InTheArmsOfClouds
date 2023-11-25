using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafItemManager : MonoBehaviour
{
    //public CraftableItem CraftableItem;
    private List<RecipeItem> allMaterialLists;
    public List<CraftableItem> craftableItemsList;

    //Add all material list of craf item  to one list 
    public void CombineMaterialList(){
        allMaterialLists = new List<RecipeItem>();
        foreach (var craftableItem in craftableItemsList)
        {
            foreach (var materialList in craftableItem.materialList)
            {
                allMaterialLists.Add(materialList);
            }
        }

    }
    public bool IsItemCanBeCrafted(CraftableItem craftableItem){
        foreach(RecipeItem material in craftableItem.materialList){
            if(InventoryHolder.Instance.InventorySystem.GetAmountItemInInventory(material.item) < material.amountRequired) 
                Debug.Log(" Number of item " + material.item.nameItem + "isn't enought or dont't have");
                return false;         
            }
        return true;
    }

    public void UpdateInventoryAfterCraftSucess(CraftableItem craftableItem){
        
        if(IsItemCanBeCrafted(craftableItem)){
            foreach(RecipeItem material in craftableItem.materialList){
                InventoryHolder.Instance.InventorySystem.RemoveToInventory(material.item, material.amountRequired);
            }
            InventoryHolder.Instance.InventorySystem.AddToInventory(craftableItem.crafItem, 1);
        }
    }
}
