using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData", order = 0)]

public class InventoryItemData : ScriptableObject
{
    public ItemType type;
    //public ItemDataType ID;
    public string name;

    [TextArea(4,4)]
    public string description;
    public Sprite Icon;
    public int maxStackSize;
    public int healthItem;
    public int luckItem;
    public int sanityItem;

}
