using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMovement : MonoBehaviour, IEnemyComponent
{
    private Enemy _enemy;
    private Entity _target;
    private EnemyAttack _enemyAttack;

    public bool DoAttack = false;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _enemyAttack = enemy.GetCompo<EnemyAttack>();
    }

    public void MoveToTargetPos(Transform _targetPos)
    {
        var targetDis = _enemy.Stat.AttackDistance;

        float distanceToTarget = Vector3.Distance(transform.position, _targetPos.position);

        if (distanceToTarget <= targetDis)
        {
            DoAttack = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, _enemy.Stat.MoveSpeed * Time.deltaTime);
        }
    }
}
