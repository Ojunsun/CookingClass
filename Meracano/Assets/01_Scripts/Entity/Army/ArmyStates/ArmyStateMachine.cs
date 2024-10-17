using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyStateMachine
{
    public ArmyState currentState { get; private set; }

    public void Initialize(ArmyState startState)
    {
        currentState = startState;
        currentState.Enter();
    }

    public void ChangeState(ArmyState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void UpdateMachine()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }
}
