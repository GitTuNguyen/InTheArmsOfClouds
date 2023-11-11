using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalWalkState : AnimalBaseState
{
    public override void EnterState(AnimalStateMachine animal)
    {
        Debug.Log("Walk state");
        animal.animator.SetBool("isWalk", true);
        animal.animator.SetBool("isIdle", false);
    }

    public override void UpdateState(AnimalStateMachine animal)
    {
        //Debug.Log("Ssearching food");
        animal.animalController.AnimalWalking();
    }
}
