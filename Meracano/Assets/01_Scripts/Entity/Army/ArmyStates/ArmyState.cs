using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmyState
{
    protected Player _army;
    protected ArmyStateMachine _stateMachine;
    protected int _animBoolHash;

    protected bool _animationTriggered;
    protected Animator _anim;

    public ArmyState(Player army, ArmyStateMachine stateMachine, string animBoolName)
    {
        _army = army;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);
        _anim = _army.GetCompo<EnemyAnimator>().Anim;
    }

    public virtual void Enter()
    {
        _animationTriggered = false;
        _anim.SetBool(_animBoolHash, true);
    }

    public virtual void UpdateState()
    {

    }

    public virtual void Exit()
    {
        _anim.SetBool(_animBoolHash, false);
    }

    public void SetAnimationTrigger()
    {
        _animationTriggered = true;
    }
}
