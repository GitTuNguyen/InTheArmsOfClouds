using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CraftingRecipe
{
    public List<string> requiredItems;
    public Item craftedItem;
    public string resultItem;
    public string description;
    public int healthEffect;
    public int luckEffect;
    public int sanityEffect;
}
