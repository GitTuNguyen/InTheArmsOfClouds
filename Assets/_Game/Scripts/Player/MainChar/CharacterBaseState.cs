using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState 
{
    public abstract void EnterState(CharacterStateMachine player);
    public abstract void UpdateState(CharacterStateMachine player);

    public abstract void OnTriggerEnter(CharacterStateMachine player, Collider collision);
}
