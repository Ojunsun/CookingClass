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
        };
    }

    public override EnemyState GetState(Enum enumType)
    {
        throw new NotImplementedException();
    }
}
