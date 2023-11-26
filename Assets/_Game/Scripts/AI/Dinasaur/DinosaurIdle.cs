using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurIdle : DinosaurBaseState
{
    float timeLine;

    private float timeToSwitchIdleState;
    public override void EnterState(DinasaurStateMachine animal)
    {
        animal.animator.SetBool("isIdle", true);
        animal.animator.SetBool("isWalk", false);
        animal.animalController.hungerStats = Random.Range(40, 60);
        animal.animalController.thirstStats = Random.Range(50, 60);
        timeToSwitchIdleState = Random.Range(5, 10);
        animal.GetComponent<BoxCollider>().enabled = true;
        timeLine = 0;
    }

    public override void OnTriggerEnter(DinasaurStateMachine animal, Collider collision)
    {
        
    }

    public override void UpdateState(DinasaurStateMachine animal)
    {
        timeLine += Time.deltaTime;

        if (animal.animalController.IsSearchFoodAndDrink())
        {
            Debug.Log("Dinosaur walk");
            animal.SwitchState(AnimalState.Walk);
        }

        if (timeLine > timeToSwitchIdleState)
        {
            animal.SwitchState(AnimalState.Walk);
            Debug.Log("Dinosaur walk");
        }


        animal.animalController.UpdateStateOfAnimal(2, 2, 1);
    }
}
