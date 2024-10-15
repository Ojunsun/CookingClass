using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeIdle : EnemyState
{
    public EnemyMeleeIdle(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void Exit()
    {
        base.Exit();
    }
}