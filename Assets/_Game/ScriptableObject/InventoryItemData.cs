using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData/Normal Item", order = 0)]

public class InventoryItemData : ScriptableObject
{
    public ItemType type;
    public string nameItem;

    [TextArea(4,4)]
    public string description;
    public Sprite icon;
    public int maxStackSize;
    public int healthItem;
    public int luckItem;
    public int sanityItem;

}
