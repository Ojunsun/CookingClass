using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IEnemyComponent
{
    private Enemy _enemy;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void AttackTarget()
    {
        var damage = _enemy.Stat.Damage;
        _enemy.DamageCasterCompo.CastDamage(damage);
    }
}
