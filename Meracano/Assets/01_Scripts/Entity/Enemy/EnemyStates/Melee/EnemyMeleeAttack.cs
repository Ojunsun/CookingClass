using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyMeleeAttack : EnemyState
{
    public EnemyMeleeAttack(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_enemy.Target.IsDead)
        {
            _enemy.DoAttack = false;
            _stateMachine.ChangeState(_enemy.GetState(ArmyMeleeState.Idle));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
