using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalEatState : AnimalBaseState
{
    public override void EnterState(AnimalStateMachine animal)
    {
        Debug.Log("Eat state");
        animal.animator.SetBool("isWalk", false);
        animal.animator.SetBool("isEating", true);
        animal.animator.SetBool("isIdle", false);
    }

    public override void UpdateState(AnimalStateMachine animal)
    {
       if(animal.animalController.IsEating)
        {
            animal.animalController.UpdateStateOfAnimal(-5, 1, 1);
        }

        if (animal.animalController.IsDrinking)
        {
            animal.animalController.UpdateStateOfAnimal(1, -2, 1);
        }

        if(animal.animalController.Hunger == 0 || animal.animalController.Thirst == 0)
        {
            animal.SwitchState(AnimalState.Walk);
        }
    }

    public override void OnCollisionEnter(AnimalStateMachine animal, Collision collision)
    {

    }
}
