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

    
    public int shield;
    private void OnEnable()
    {
        EventManager.PlayerDie += ResetPlayerStats;
    }

    private void OnDisable()
    {
        EventManager.PlayerDie -= ResetPlayerStats;
    }
    private void Start()
    {
        ResetPlayerStats();
        GameManager.Instance.player = this;
    }

    public void UpdateStatsOfPlayer(int health, int luck, int santity)
    {
        if (shield <= 0)
        {            
            this.health += health;
        }
        this.luck += luck;
        this.santity += santity;
        this.luck = this.luck > 5 ? 5 : this.luck;
        this.health = this.health > 5 ? 5 : this.health;
        this.santity = this.santity > 5 ? 5 : this.santity;
        ActionPhaseUIManager.Instance.RefreshPlayerStatsUI(this.health, this.luck, this.santity);
        if (this.health == 0 || this.luck == 0 || this.santity == 0)
        {
            EventManager.PlayerDie?.Invoke();
        }
    }

    public void ResetPlayerStats()
    {
        health = 5;
        luck = 5;
        santity = 5;
        ActionPhaseUIManager.Instance.RefreshPlayerStatsUI(this.health, this.luck, this.santity);
    }
}
