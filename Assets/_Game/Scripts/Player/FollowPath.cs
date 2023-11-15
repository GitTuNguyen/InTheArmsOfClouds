using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Follow path");
        player.playerController.StartFollowPath();
    }

    public override void OnCollisionEnter(PlayerStateManager player, Collision collision)
    {

    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(!player.playerController.PlayerFollowPath())
        {
            player.SwitchState(PlayerState.EndTurn);
        }
        
    }
}