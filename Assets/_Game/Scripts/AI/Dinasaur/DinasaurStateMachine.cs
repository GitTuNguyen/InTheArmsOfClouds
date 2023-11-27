using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DinasaurStateMachine : MonoBehaviour
{
    private DinosaurBaseState currentState;

    DinosaurIdle idle = new DinosaurIdle();
    DinosaurWalk walk = new DinosaurWalk();
    DinosaurEating eat = new DinosaurEating();
    DinosaurTurningRight turningRight = new DinosaurTurningRight();

    public Animal animalController;

    public Animator animator;

    private bool isDrinking;
    private bool isEating;

    public bool IsDrinking
    {
        get { return isDrinking; }
        set { isDrinking = value; }
    }

    public bool IsEating
    {
        get { return isEating; }
        set { isEating = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = idle;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AnimalState state)
    {
        DinosaurBaseState nextAnimalState = idle;
        switch (state)
        {
            case AnimalState.Idle:
                nextAnimalState = idle;
                break;
            case AnimalState.Walk:
                nextAnimalState = walk;
                break;
            case AnimalState.Eat:
                nextAnimalState = eat;
                break;
            case AnimalState.Turn:
                nextAnimalState = turningRight;
                break;

        }

        currentState = nextAnimalState;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }
}
