using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEndTurn : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine player)
    {
        Debug.Log("Player End turn");
        player.playerController.PlayerEndTurn();
    }

    public override void OnTriggerEnter(CharacterStateMachine player, Collider collision)
    {

    }

    public override void UpdateState(CharacterStateMachine player)
    {
        if (GameEventSystem.Instance.isEventDone)
        {
            Debug.Log("Change state to roll dice");
            player.SwitchState(PlayerState.DiceRoll);
        } 
    }


}
