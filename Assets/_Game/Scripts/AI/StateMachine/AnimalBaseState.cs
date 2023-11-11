using UnityEngine;

public abstract class AnimalBaseState
{
    public abstract void EnterState(AnimalStateMachine animal);
    public abstract void UpdateState(AnimalStateMachine animal);

}
