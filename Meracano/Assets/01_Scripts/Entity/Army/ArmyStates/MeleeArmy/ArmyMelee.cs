using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmyMeleeState
{
    Idle,
    Move,
    Attack
}

public class ArmyMelee : Player
{
    private Dictionary<ArmyMeleeState, ArmyState> stateDictionary;

    protected override void Awake()
    {
        base.Awake();
        stateDictionary = new Dictionary<ArmyMeleeState, ArmyState>(){
            {ArmyMeleeState.Idle, new ArmyMeleeIdle(this, StateMachine, "Idle") },
            {ArmyMeleeState.Move, new ArmyMeleeMove(this, StateMachine, "Move") },
            {ArmyMeleeState.Attack, new ArmyMeleeAttack(this, StateMachine, "Attack") }
        };
    }

    private void Start()
    {
        StateMachine.Initialize(stateDictionary[ArmyMeleeState.Idle]);
    }

    public override void Init()
    {
        base.Init();
        StateMachine.Initialize(stateDictionary[ArmyMeleeState.Idle]);
    }

    public override ArmyState GetState(Enum enumType)
    {
        var state = (ArmyMeleeState)enumType;
        if(stateDictionary.TryGetValue(state, out ArmyState armyState))
        {
            return armyState;
        }
        return null;
    }
}
