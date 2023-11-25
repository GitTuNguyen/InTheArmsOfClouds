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
       if(animal.IsEating)
        {
            animal.animalController.UpdateStateOfAnimal(-10, 1, 1);
        }

        if (animal.IsDrinking)
        {
            animal.animalController.UpdateStateOfAnimal(1, -10, 1);
        }

        if(animal.animalController.Hunger == 0 || animal.animalController.Thirst == 0)
        {
            animal.SwitchState(AnimalState.Walk);
        }
    }

    public override void OnTriggerEnter(AnimalStateMachine animal, Collider collision)
    {
        //if(collision.gameObject.tag == "Food")
        //{
        //    isEating = true;
        //}

        //if(collision.gameObject.tag == "Water")
        //{
        //    isDrinking = true;  
        //}
    }
}
