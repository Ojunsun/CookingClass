using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    private Entity _onwer;

    private void Awake()
    {
        _onwer = GetComponentInParent<Entity>();
    }

    public void CastMeleeDamage()
    {
        _onwer.HealthCompo.ApplyDamage(_onwer.Stat.damage);
    }
}