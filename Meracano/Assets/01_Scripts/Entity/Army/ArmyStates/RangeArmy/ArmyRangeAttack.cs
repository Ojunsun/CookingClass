using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyRangeAttack : ArmyState
{
    private PlayerMovement _movementCompo;
    private Entity _target;

    public ArmyRangeAttack(Player army, ArmyStateMachine stateMachine, string animBoolName) : base(army, stateMachine, animBoolName)
    {
        _movementCompo = army.GetCompo<PlayerMovement>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _target = _army.FindNearestTarget<Entity>(50f, _army.TargetLayer);
        _movementCompo.LookTarget(_target.transform);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
