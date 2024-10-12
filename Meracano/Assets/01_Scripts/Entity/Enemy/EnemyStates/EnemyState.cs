using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyState 
{
    protected Enemy _enemy;
    protected EnemyStateMachine _stateMachine;
    protected int _animBoolHash;

    protected bool _animationTriggered;
    protected Animator _anim;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);
        _anim = _enemy.GetCompo<EnemyAnimator>().Anim;
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
