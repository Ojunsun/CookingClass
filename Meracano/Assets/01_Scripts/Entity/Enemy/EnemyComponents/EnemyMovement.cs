using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IEnemyComponent
{
    private Enemy _enemy;
    private Entity _target;
    private EnemyAttack _enemyAttack;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _enemyAttack = enemy.GetCompo<EnemyAttack>();
    }

    private void OnEnable()
    {
        EventManager.OnBattleStartEvent += OnBattleStartEventHandler;
    }

    private void OnBattleStartEventHandler()
    {
        _target = _enemy.FindNearestTarget<Entity>(50f, _enemy.TargetLayer);

        MoveToTargetPos(_target.transform);
    }

    public void MoveToTargetPos(Transform _targetPos)
    {
        StartCoroutine(MoveToTarget(_targetPos));
    }

    private IEnumerator MoveToTarget(Transform _targetPos)
    {
        var targetDis = _enemy.Stat.attackDistance;

        while (true)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _targetPos.position);

            if (distanceToTarget <= targetDis)
            {
                _enemyAttack.AttackTarget();
                yield break;
            }

            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, _enemy.Stat.moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
