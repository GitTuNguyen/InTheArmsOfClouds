using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/Special_Item", order = 0)]
public class InventoryCraftableItem : ScriptableObject {
    public InventoryItemData crafItem;
    
    public List<RecipeItem> materialList;
}

[System.Serializable] public struct RecipeItem
    {
        public InventoryItemData item;
        public int required;
    }