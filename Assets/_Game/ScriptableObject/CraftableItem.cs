using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/Special_Item", order = 0)]
public class CraftableItem : ScriptableObject {
    public InventoryItemData crafItem;
    public string description;
    public List<RecipeItem> materialList;
}

[System.Serializable] public struct RecipeItem
    {
        public InventoryItemData item;
        public int amountRequired;
    }