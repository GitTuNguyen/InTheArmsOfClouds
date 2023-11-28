using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Definition 
{
   
}

public enum BlockType
{
    Grass,
    Sea,
    Desert,
    Wood,
    SpaceShip
}
public enum SpeciesType
{
    Plant,
    Animal
}

public enum Status
{
    Sleeping,
    Childe,
    Adults
}

public enum Gender
{
    Male,
    Female
}

public enum AnimalType
{
    Deer,
    Horse,
    Dog,
    Dinaso
}

public enum AnimalState
{
    Idle,
    Walk,
    Run,
    Eat,
    Turn,
    Die
}

public enum PlayerState
{
    DiceRoll,
    SelectPath,
    FollowPath,
    TriggerEvent,
    EndTurn
}

public enum ItemType
{
    Meat = 0,
    GrilledMeat,
    Log,
    Crop,
    Seashell,
    Gem,
    MagicScroll,
    Salad,
    EnchantedStew,
    Shield,
    Amulet,
    SpaceShip
}


public enum CrafItemType
{
    GrilledMeat,
    Salad,
    EnchantedStew,
    Shield,
    Amulet,
    SpaceShip
}