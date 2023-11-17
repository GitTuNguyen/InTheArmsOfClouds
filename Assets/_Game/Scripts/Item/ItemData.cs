using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData", order = 0)]

public class ItemData : ScriptableObject
{
    public string nameItem;
    public Sprite imageItem;
    public int healthItem;
    public int luckItem;
    public int sanityItem;
    public int maxCapacity;
}
