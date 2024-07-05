using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectPath : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine player)
    {
        Debug.Log("");
        player.playerController.playerUI.EnableUICanvas(GameManager.Instance.currentDiceNumber);
        player.playerController.StartSelectPath();        
        ActionPhaseUIManager.Instance.rollDiceButton.enabled = false;
    }

    public override void OnTriggerEnter(CharacterStateMachine player, Collider collision)
    {

    }

    public override void UpdateState(CharacterStateMachine player)
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
