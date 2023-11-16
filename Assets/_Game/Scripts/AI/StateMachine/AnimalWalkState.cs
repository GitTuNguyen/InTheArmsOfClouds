using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AnimalWalkState : AnimalBaseState
{
    private bool isTurnRight;

    private bool isTurnLeft;

    private bool isTurning;

    private float timeToSwitchIdleState;

    float timeLine;

    public override void EnterState(AnimalStateMachine animal)
    {
        Debug.Log("Walk state");
        animal.animator.SetBool("isWalk", true);
        animal.animator.SetBool("isIdle", false);
        animal.animator.SetBool("isEating", false);
        timeToSwitchIdleState = Random.Range(8,12);
        timeLine = 0;
    }

    public override void UpdateState(AnimalStateMachine animal)
    {
        timeLine += Time.deltaTime;
         
        if(timeLine > timeToSwitchIdleState)
        {
            animal.SwitchState(AnimalState.Idle);
        }

        animal.animalController.UpdateStateOfAnimal(2, 1, 1);
        //Debug.Log("Ssearching food");
        animal.animalController.AnimalWalking();

        // Vision
        Vector3 posTarget = Vector3.zero;

        GameObject leftVision = animal.animalController.leftVision;

        GameObject rightVision = animal.animalController.rightVision;

        RaycastHit rightHit;

        Vector3 rightRay = animal.animalController.rightVision.transform.forward;

        if (Physics.Raycast(animal.animalController.rightVision.transform.position, rightRay.normalized, 1, animal.animalController.obstacleLayerMask))
        {
            //Debug.Log("rightVision detection");

            isTurnRight = true;

            posTarget = new Vector3(leftVision.transform.position.x + leftVision.transform.forward.x, animal.transform.position.y, leftVision.transform.position.z + leftVision.transform.forward.z);
        }


        RaycastHit leftHit;

        Vector3 leftRay = leftVision.transform.forward;

        if (Physics.Raycast(leftVision.transform.position, leftRay.normalized, 1, animal.animalController.obstacleLayerMask))
        {
            //Debug.Log("leftVision detection");

            posTarget = new Vector3(rightVision.transform.position.x + rightVision.transform.forward.x, animal.transform.position.y, rightVision.transform.position.z + rightVision.transform.forward.z);

            isTurnLeft = true;
        }

        if (isTurnLeft && isTurnRight)
        {
            isTurning = true;
            posTarget = animal.transform.position - animal.transform.forward;
        }

        if (isTurnLeft || isTurnRight)
        {
            isTurnLeft = false;
            isTurnRight = false;
            animal.transform.LookAt(posTarget);
        }

    }

    public override void OnCollisionEnter(AnimalStateMachine animal, Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            animal.SwitchState(AnimalState.Eat);
            animal.GetComponent<BoxCollider>().enabled = false; 
        }
    }
}
