using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour, IEnemyComponent
{
    private Enemy _enemy;
    public Animator Anim { get; private set; }

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        Anim = GetComponent<Animator>();
    }
}
