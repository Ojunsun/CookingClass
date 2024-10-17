using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DamageCaster : MonoBehaviour
{
    private Entity _onwer;


    private void Awake()
    {
        _onwer = GetComponentInParent<Entity>();
    }

    public void CastMeleeDamage()
    {
        var target = _onwer.FindNearestTarget<Entity>(_onwer.Stat.AttackDistance, _onwer.TargetLayer);
        
        if(target != null)
        {
            target.HealthCompo.ApplyDamage(_onwer.Stat.Damage);
        }
    }
}