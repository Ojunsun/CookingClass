using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMeleeAttack : ArmyState
{
    private Entity _target;

    public ArmyMeleeAttack(Player army, ArmyStateMachine stateMachine, string animBoolName) : base(army, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _target = _army.FindNearestTarget<Entity>(_army.Stat.AttackDistance, _army.TargetLayer);
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(_target == null)
        {
            _army.DoAttack = false;
            _stateMachine.ChangeState(_army.GetState(ArmyMeleeState.Move));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
