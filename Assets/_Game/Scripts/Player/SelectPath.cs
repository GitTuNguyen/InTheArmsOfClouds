using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SelectPath : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player.playerController.playerUI.EnableUICanvas(player.playerController.numberDice);
        player.playerController.StartSelectPath();
        ActionPhaseUIManager.Instance.rollDiceButton.enabled = false;
    }

    public override void OnTriggerEnter(PlayerStateManager player, Collider collision)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        player.playerController.PlayerSelectPath();
        if(player.playerController.PlayerCanMove()) 
        {
            player.SwitchState(PlayerState.FollowPath);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            player.playerController.PlayerResetPath();
        }
    }
}
