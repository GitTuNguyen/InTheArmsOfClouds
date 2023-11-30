using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTriggerEvent : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine player)
    {
        Debug.Log("Player CharacterTriggerEvent");
        player.playerController.PlayerTriggerEvent();
    }

    public override void OnTriggerEnter(CharacterStateMachine player, Collider collision)
    {

    }

    public override void UpdateState(CharacterStateMachine player)
    {
        player.SwitchState(PlayerState.EndTurn);
    }
}
