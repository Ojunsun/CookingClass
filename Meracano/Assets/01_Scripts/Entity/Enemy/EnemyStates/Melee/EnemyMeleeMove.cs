using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyMeleeMove : EnemyState
{
    private EnemyMovement _movementCompo;
    private Entity _target;

    public EnemyMeleeMove(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
        _movementCompo = _enemy.GetCompo<EnemyMovement>();
    }

    public override void Enter()
    {
        base.Enter();
        _target = _enemy.FindNearestTarget<Entity>(50f, _enemy.TargetLayer);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_enemy.IsBattle)
        {
            _movementCompo.MoveToTargetPos(_target.transform);
            _movementCompo.LookTarget(_target.transform);
        }


        if (_enemy.DoAttack)
        {
            _stateMachine.ChangeState(_enemy.GetState(EnemyMeleeState.Attack));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
