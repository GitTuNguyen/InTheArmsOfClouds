using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurEating : DinosaurBaseState
{
    public override void EnterState(DinasaurStateMachine animal)
    {
        animal.animator.SetBool("isWalk", false);
        animal.animator.SetBool("isIdle", true);
    }

    public override void OnTriggerEnter(DinasaurStateMachine animal, Collider collision)
    {
        
    }

    public override void UpdateState(DinasaurStateMachine animal)
    {
        if (animal.IsEating)
        {
            animal.animalController.UpdateStateOfAnimal(-10, 1, 1);
        }

        if (animal.IsDrinking)
        {
            animal.animalController.UpdateStateOfAnimal(1, -10, 1);
        }

        if (animal.animalController.Hunger == 0 || animal.animalController.Thirst == 0)
        {
            animal.SwitchState(AnimalState.Walk);
        }
    }

}
