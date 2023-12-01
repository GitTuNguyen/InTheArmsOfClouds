using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Player trigger event");
        SFXManager.Instance?.StopSound("Step");
        player.playerController.PlayerTriggerEvent();
    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider collision)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.SwitchState(PlayerState.EndTurn);
    }

    
}
