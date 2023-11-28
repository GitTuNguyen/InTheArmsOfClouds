using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DinosaurTurningRight : DinosaurBaseState
{
    float timeLine;
    float time;
    public override void EnterState(DinasaurStateMachine animal)
    {
        animal.animator.SetTrigger("turnRight");
        animal.animator.SetBool("isWalk", false);
        time = 3.113f;
        timeLine = 0;
    }

    public override void OnTriggerEnter(DinasaurStateMachine animal, Collider collision)
    {
       
    }

    public override void UpdateState(DinasaurStateMachine animal)
    {
        if(timeLine > time)
        {
            animal.gameObject.transform.Rotate(0, 180, 0);
            animal.SwitchState(AnimalState.Walk);
        }
        timeLine += Time.deltaTime;
    }

}
