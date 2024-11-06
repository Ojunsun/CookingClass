using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyRangeAttack : ArmyState
{
    private PlayerMovement _movementCompo;

    public ArmyRangeAttack(Player army, ArmyStateMachine stateMachine, string animBoolName) : base(army, stateMachine, animBoolName)
    {
        _movementCompo = army.GetCompo<PlayerMovement>();
    }

    public override void Enter()
    {
        base.Enter();
        _army.Target = _army.FindNearestTarget<Entity>(50f, _army.TargetLayer);
        _movementCompo.LookTarget(_army.Target.transform);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_army.Target.IsDead)
        {
            _stateMachine.ChangeState(_army.GetState(ArmyRangeState.Idle));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
