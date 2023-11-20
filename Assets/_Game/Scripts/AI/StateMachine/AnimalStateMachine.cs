using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStateMachine : MonoBehaviour
{
    private AnimalBaseState currentState;
    AnimalIdleState idleSate = new AnimalIdleState();
    AnimalWalkState walkState = new AnimalWalkState();
    AnimalRunState runState = new AnimalRunState();
    AnimalEatState eatState = new AnimalEatState();
    AnimalDieState dieState = new AnimalDieState();

    public Animator animator;

    public Animal animalController;

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
        currentState = idleSate;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AnimalState state)
    {
        AnimalBaseState nextAnimalState = idleSate;
        switch (state)
        {
            case AnimalState.Idle:
                nextAnimalState = idleSate;
                break;
            case AnimalState.Walk:
                nextAnimalState = walkState;
                break;
            case AnimalState.Run:
                nextAnimalState = runState;
                break;
            case AnimalState.Eat:
                nextAnimalState = eatState;
                break;
            case AnimalState.Die:
                nextAnimalState = dieState;
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
