using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IEnemyComponent
{
    private Enemy _enemy;
    private Entity _target;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy ;
    }

    private void OnEnable()
    {
        EventManager.OnBattleStartEvent += OnBattleStartEventHandler;
    }

    private void OnBattleStartEventHandler()
    {
        _target = _enemy.FindNearestTarget<Entity>(50f, _enemy.TargetLayer);

        _enemy.MoveToTargetPos(_target.transform);
    }
}
