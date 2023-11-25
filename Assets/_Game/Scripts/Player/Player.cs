using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    private int luck;
    public int Luck
    {
        get { return luck; }
        set { luck = value; }
    }
    private int santity;
    public int Santity
    {
        get { return santity; }
        set { santity = value; }
    }

    private void Start()
    {
        health = 5;
        luck = 5;
        santity = 5;
    }

    public void UpdateStatsOfPlayer(int health, int luck, int santity)
    {
        this.health += health;
        this.luck += luck;
        this.santity += santity;
    }
}
