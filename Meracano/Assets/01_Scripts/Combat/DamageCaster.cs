using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    private Entity _onwer;
    private Health _health;

    private void Awake()
    {
        _onwer = GetComponentInParent<Entity>();
    }

    public void CastMeleeDamage()
    {
        _health.ApplyDamage(_onwer.Stat.damage);
    }
}