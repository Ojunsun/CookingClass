using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyMeleeAttack : EnemyState
{
    private EnemyMovement _movementCompo;

    public EnemyMeleeAttack(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
        _movementCompo = _enemy.GetCompo<EnemyMovement>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _movementCompo.LookTarget(_enemy.Target.transform);

        if (_enemy.Target.IsDead || !_enemy.DoAttack)
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
