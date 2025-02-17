using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalIdleState : AnimalBaseState
{
    float timeLine;

    private float timeToSwitchIdleState;
    public override void EnterState(AnimalStateMachine animal)
    {
        animal.animator.SetBool("isIdle", true);
        animal.animator.SetBool("isWalk", false);
        animal.animalController.hungerStats = Random.Range(40, 60);
        animal.animalController.thirstStats = Random.Range(50,60);
        timeToSwitchIdleState = Random.Range(5, 10);
        animal.GetComponent<BoxCollider>().enabled = true;
        timeLine = 0;
    }

    public override void UpdateState(AnimalStateMachine animal)
    {
        timeLine += Time.deltaTime;

        if (animal.animalController.IsSearchFoodAndDrink())
        {
            animal.SwitchState(AnimalState.Walk);
        }

        if (timeLine > timeToSwitchIdleState)
        {
            animal.SwitchState(AnimalState.Walk);
        }


        animal.animalController.UpdateStateOfAnimal(2, 2, 1);
    }

    public override void OnTriggerEnter(AnimalStateMachine animal, Collider collision)
    {

    }
}
