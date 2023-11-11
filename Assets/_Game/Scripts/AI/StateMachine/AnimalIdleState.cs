using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalIdleState : AnimalBaseState
{
    public override void EnterState(AnimalStateMachine animal)
    {
        animal.animator.SetBool("isIdle", true);
    }

    public override void UpdateState(AnimalStateMachine animal)
    {
        if (animal.animalController.IsSearchFoodAndDrink())
        {
            animal.SwitchState(AnimalState.Walk);
        }
    }
}
