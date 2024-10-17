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

        if(_enemy.IsBattle)
        {
            _stateMachine.ChangeState(_enemy.GetState(EnemyMeleeState.Move));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
