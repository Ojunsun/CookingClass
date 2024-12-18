using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum EnemyMeleeState
{
    Idle,
    Move,
    Attack
}

public class EnemyMelee : Enemy
{
    private Dictionary<EnemyMeleeState, EnemyState> stateDictionary;

    protected override void Awake()
    {
        base.Awake();
        stateDictionary = new Dictionary<EnemyMeleeState, EnemyState>(){
            {EnemyMeleeState.Idle, new EnemyMeleeIdle(this, StateMachine, "Idle") },
            {EnemyMeleeState.Move, new EnemyMeleeMove(this, StateMachine, "Move") },
            {EnemyMeleeState.Attack, new EnemyMeleeAttack(this, StateMachine, "Attack") }
        };
    }

    private void Start()
    {
        StateMachine.Initialize(stateDictionary[EnemyMeleeState.Idle]);
    }

    public override void Init()
    {
        base.Init();

        StateMachine.Initialize(stateDictionary[EnemyMeleeState.Idle]);
    }

    public override EnemyState GetState(Enum enumType)
    {
        var state = (EnemyMeleeState)enumType;
        if (stateDictionary.TryGetValue(state, out EnemyState enemyState))
        {
            return enemyState;
        }
        return null;
    }
}
