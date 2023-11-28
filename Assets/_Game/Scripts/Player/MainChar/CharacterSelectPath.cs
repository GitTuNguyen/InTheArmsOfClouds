using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectPath : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine player)
    {
        player.playerController.playerUI.EnableUICanvas(player.playerController.numberDice);
        player.playerController.StartSelectPath();
    }

    public override void OnTriggerEnter(CharacterStateMachine player, Collider collision)
    {

    }

    public override void UpdateState(CharacterStateMachine player)
    {
        player.playerController.PlayerSelectPath();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchState(PlayerState.FollowPath);
        }
    }
}
