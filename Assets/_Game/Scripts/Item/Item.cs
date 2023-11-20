using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemName
    {
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
    public ItemName itemName;
    public Sprite imageItem;
    public int healthItem;
    public int luckItem;
    public int sanityItem;
    public int maxCapacity;

}
