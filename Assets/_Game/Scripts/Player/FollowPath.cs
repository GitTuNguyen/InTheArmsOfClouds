using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Follow path");
        player.playerController.playerUI.DisableUICanvas();
        player.playerController.StartFollowPath();
    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Block block = collision.gameObject.GetComponent<Block>();
            if(block != null)
            {
                block.RemoveCloudOfBlock();
            }
        }
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(!player.playerController.PlayerFollowPath())
        {
            player.SwitchState(PlayerState.EndTurn);
        }
        
    }
}