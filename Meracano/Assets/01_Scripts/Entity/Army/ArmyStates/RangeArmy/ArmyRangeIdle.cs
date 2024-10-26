using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyRangeIdle : ArmyState
{
    public ArmyRangeIdle(Player army, ArmyStateMachine stateMachine, string animBoolName) : base(army, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_army.IsBattle)
        {
            _stateMachine.ChangeState(_army.GetState(ArmyRangeState.Attack));
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
