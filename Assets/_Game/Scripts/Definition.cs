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
    Wood
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