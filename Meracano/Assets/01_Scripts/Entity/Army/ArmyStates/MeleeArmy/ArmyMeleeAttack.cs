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
    }

    public override void Exit()
    {
        base.Exit();
    }
}
