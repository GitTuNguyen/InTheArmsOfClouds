using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData", order = 0)]

public class InventoryItemData : ScriptableObject
{
    public enum ItemDataType{
        Meat = 1,
        Log,
        Crop,
        Seashell,
        Gem,
        MagicScroll,
        GrilledMeat,
        Salad,
        EnchantedStew,
        Shield,
        Amulet,
        SpaceShip
    }
    public ItemDataType ID;
    public string DisplayName;

    [TextArea(4,4)]
    public string Description;
    public Sprite Icon;
    public int MaxStackSize;
    public int healthItem;
    public int luckItem;
    public int sanityItem;

}
