using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndTurn : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Player End turn");
        player.playerController.PlayerEndTurn();
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.SwitchState(PlayerState.SelectPath);
    }


}
