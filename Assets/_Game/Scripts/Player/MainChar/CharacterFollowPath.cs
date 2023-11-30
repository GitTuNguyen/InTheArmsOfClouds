using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollowPath : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine player)
    {
        Debug.Log("Follow path");
        player.playerController.playerUI.DisableUICanvas();
        player.playerController.StartFollowPath();
    }

    public override void OnTriggerEnter(CharacterStateMachine player, Collider collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Block block = collision.gameObject.GetComponent<Block>();
            if (block != null)
            {
                block.RemoveCloudOfBlock();
            }
        }
    }

    public override void UpdateState(CharacterStateMachine player)
    {
        if (!player.playerController.PlayerFollowPath())
        {
            player.SwitchState(PlayerState.TriggerEvent);
        }

    }
}
