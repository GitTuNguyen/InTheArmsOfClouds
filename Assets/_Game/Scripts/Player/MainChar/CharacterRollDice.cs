using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRollDice : CharacterBaseState
{
    public override void EnterState(CharacterStateMachine player)
    {
        player.playerController.playerUI.DisableUICanvas();
        player.playerController.PlayerRollDice();
        ActionPhaseUIManager.Instance.rollDiceButton.enabled = true;
    }

    public override void OnTriggerEnter(CharacterStateMachine player, Collider collision)
    {

    }

    public override void UpdateState(CharacterStateMachine player)
    {

    }
}
