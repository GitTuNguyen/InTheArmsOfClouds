using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DinosaurWalk : DinosaurBaseState
{
    private bool isTurnRight;

    private bool isTurnLeft;

    private bool isTurning;

    private float timeToSwitchIdleState;

    float timeLine;
    public override void EnterState(DinasaurStateMachine animal)
    {
        animal.animator.SetBool("isWalk", true);
        animal.animator.SetBool("isIdle", false);
        timeToSwitchIdleState = Random.Range(5, 10);
        animal.IsEating = false;
        animal.IsDrinking = false;
        timeLine = 0;
        isTurning = false;
    }

    public override void OnTriggerEnter(DinasaurStateMachine animal, Collider collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            animal.IsEating = true;
            animal.SwitchState(AnimalState.Eat);
        }

        if (collision.gameObject.tag == "Water")
        {
            animal.IsDrinking = true;
            animal.SwitchState(AnimalState.Eat);
        }

    }

    public override void UpdateState(DinasaurStateMachine animal)
    {
        timeLine += Time.deltaTime;

        if (timeLine > timeToSwitchIdleState)
        {
            animal.SwitchState(AnimalState.Idle);
        }
        animal.animalController.CheckEnableBigBoxCollider();
        animal.animalController.UpdateStateOfAnimal(1, 1, 1);
        //Debug.Log("Ssearching food");
        animal.animalController.AnimalWalking();

        // Vision
        Vector3 posTarget = Vector3.zero;

        GameObject leftVision = animal.animalController.leftVision;

        GameObject rightVision = animal.animalController.rightVision;


        Vector3 rightRay = animal.animalController.rightVision.transform.forward;

        if (Physics.Raycast(animal.animalController.rightVision.transform.position, rightRay.normalized, 1, animal.animalController.obstacleLayerMask))
        {
            //Debug.Log("rightVision detection");

            isTurnRight = true;

            posTarget = new Vector3(leftVision.transform.position.x + leftVision.transform.forward.x, animal.transform.position.y, leftVision.transform.position.z + leftVision.transform.forward.z);
        }


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
            //posTarget = animal.transform.position - animal.transform.forward;
            animal.SwitchState(AnimalState.Turn);
        }

        if ((isTurnLeft || isTurnRight) && !isTurning)
        {
            animal.transform.LookAt(posTarget);
        }
        isTurnLeft = false;
        isTurnRight = false;
    }

}
