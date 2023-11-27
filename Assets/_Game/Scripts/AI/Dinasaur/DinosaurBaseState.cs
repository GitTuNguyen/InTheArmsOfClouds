using UnityEngine;

public abstract class DinosaurBaseState 
{
    public abstract void EnterState(DinasaurStateMachine animal);
    public abstract void UpdateState(DinasaurStateMachine animal);

    public abstract void OnTriggerEnter(DinasaurStateMachine animal, Collider collision);
}