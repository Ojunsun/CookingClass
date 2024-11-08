using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMeleeAttack : ArmyState
{
    PlayerMovement _movementCompo;

    public ArmyMeleeAttack(Player army, ArmyStateMachine stateMachine, string animBoolName) : base(army, stateMachine, animBoolName)
    {
        _movementCompo = _army.GetCompo<PlayerMovement>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _movementCompo.LookTarget(_army.Target.transform);

        if (_army.Target.IsDead || !_army.DoAttack)
        {
            _army.DoAttack = false;
            _stateMachine.ChangeState(_army.GetState(ArmyMeleeState.Idle));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
