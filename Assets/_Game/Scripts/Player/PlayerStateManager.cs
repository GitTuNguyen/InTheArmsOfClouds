using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState currentState;
    RollDice rollDice = new RollDice();
    SelectPath selectPath = new SelectPath();
    FollowPath followPath = new FollowPath();
    TriggerEvent triggerEvent = new TriggerEvent();
    PlayerEndTurn playerEndTurn = new PlayerEndTurn();

    public PlayerController playerController;

    private void OnEnable()
    {
        EventManager.SwitchStateToSelectPath += SwitchToSelectPathState;
        EventManager.PlayerDie += ResetPlayerStateMachine;
    }

    private void OnDisable()
    {
        EventManager.SwitchStateToSelectPath -= SwitchToSelectPathState;
        EventManager.PlayerDie -= ResetPlayerStateMachine;
    }

    // Start is called before the first frame update
    void Start()
    {
        //EventManager.Instance.SwitchStateToSelectPath += SwitchToSelectPathState;
        currentState = rollDice;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerState state)
    {
        PlayerBaseState nextPlayerState = selectPath;
        switch (state)
        {
            case PlayerState.DiceRoll:
                nextPlayerState = rollDice;
                break;
            case PlayerState.SelectPath:
                nextPlayerState = selectPath;
                break;
            case PlayerState.FollowPath:
                nextPlayerState = followPath;
                break;
            case PlayerState.TriggerEvent:
                nextPlayerState = triggerEvent;
                break;
            case PlayerState.EndTurn:
                nextPlayerState = playerEndTurn;
                break;
        }

        currentState = nextPlayerState;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this,other);
    }
    
    private void SwitchToSelectPathState()
    {
        SwitchState(PlayerState.SelectPath);
    }

    private void ResetPlayerStateMachine()
    {
        currentState = playerEndTurn;
        currentState.EnterState(this);
    }
}
