using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMeleeAttack : ArmyState
{
    public ArmyMeleeAttack(Player army, ArmyStateMachine stateMachine, string animBoolName) : base(army, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(_army.Target.IsDead)
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
