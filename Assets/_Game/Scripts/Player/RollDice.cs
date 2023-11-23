using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollDice : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.playerController.playerUI.DisableUICanvas();
        player.playerController.PlayerRollDice();
    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider collision)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
       
    }
}
