using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationTrigger : MonoBehaviour, IEnemyComponent
{
    private Enemy _enemy;
    private EnemyAttack _attackCompo;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _attackCompo = enemy.GetCompo<EnemyAttack>();
    }

    public void AttackTrigger()
    {
        _attackCompo.AttackTarget();
    }
}
