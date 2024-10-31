using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMeleeMove : ArmyState
{
    private PlayerMovement _movementCompo;

    public ArmyMeleeMove(Player army, ArmyStateMachine stateMachine, string animBoolName) : base(army, stateMachine, animBoolName)
    {
        _movementCompo = army.GetCompo<PlayerMovement>();
    }

    public override void Enter()
    {
        base.Enter();
        _army.Target = _army.FindNearestTarget<Entity>(50f, _army.TargetLayer);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if(_army.IsBattle)
        {
            _movementCompo.MoveToTargetPos(_army.Target.transform);
            _movementCompo.LookTarget(_army.Target.transform);
        }


        if(_army.DoAttack)
        {
            _stateMachine.ChangeState(_army.GetState(ArmyMeleeState.Attack));
        }
    }

    public override void Exit() 
    { 
        base.Exit();
    }
}
