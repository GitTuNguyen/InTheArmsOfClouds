using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalIdleState : AnimalBaseState
{
    public override void EnterState(AnimalStateMachine animal)
    {
        animal.animator.SetBool("isIdle", true);
        animal.animator.SetBool("isWalk", false);
    }

    public override void UpdateState(AnimalStateMachine animal)
    {
        if (animal.animalController.IsSearchFoodAndDrink())
        {
            animal.SwitchState(AnimalState.Walk);
        }

        animal.animalController.UpdateStateOfAnimal(1, 1, 1);
    }

    public override void OnCollisionEnter(AnimalStateMachine animal, Collision collision)
    {

    }
}
