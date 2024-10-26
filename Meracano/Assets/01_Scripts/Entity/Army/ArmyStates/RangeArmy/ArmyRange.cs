using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmyRangeState
{
    Idle,
    Attack
}

public class ArmyRange : Player
{
    private Dictionary<ArmyRangeState, ArmyState> stateDictionary;

    protected override void Awake()
    {
        base.Awake();
        stateDictionary = new Dictionary<ArmyRangeState, ArmyState>(){
            {ArmyRangeState.Idle, new ArmyRangeIdle(this, StateMachine, "Idle")},
            {ArmyRangeState.Attack, new ArmyRangeAttack(this, StateMachine, "Attack")},
        };
    }

    private void Start()
    {
        StateMachine.Initialize(stateDictionary[ArmyRangeState.Idle]);
    }

    public override ArmyState GetState(Enum enumType)
    {
        var state = (ArmyRangeState)enumType;
        if (stateDictionary.TryGetValue(state, out ArmyState armyState))
        {
            return armyState;
        }
        return null;
    }
}
