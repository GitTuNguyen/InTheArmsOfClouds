using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "PrototypeContest2023/Item", order = 0)]
public class Item : ScriptableObject {
    public string itemName;
    public Sprite imagineItem;
    public int healthItem;
    public int luckItem;
    public int sanityItem;
    public int maxCapacity;

    public void Print()
    {
        Debug.Log("Name item:" + itemName + ", heal " + healthItem);
    }
}
