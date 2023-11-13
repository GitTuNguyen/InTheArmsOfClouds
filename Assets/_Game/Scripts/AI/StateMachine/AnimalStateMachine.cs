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
        nextAnimalState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
}
