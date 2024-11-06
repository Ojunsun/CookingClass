using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyDead : MonoBehaviour, IEnemyComponent
{
    private Enemy _enemy;

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
    }

    private void OnEnable()
    {
        _enemy.HealthCompo.OnDead += OnDeadHandler;
    }

    private void OnDisable()
    {
        _enemy.HealthCompo.OnDead -= OnDeadHandler;
    }

    private void OnDeadHandler()
    {
        //Á×À½ Ã³¸®
        Debug.Log(gameObject.name + "´Â »ç¸ÁÇß´Ù.");
        _enemy.IsDead = true;

        PoolManager.Instance.Push(_enemy);
    }
}
