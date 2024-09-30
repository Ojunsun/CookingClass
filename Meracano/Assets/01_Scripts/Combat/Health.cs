using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;

    private event Action OnHit;
    private event Action OnDead;

    private Entity _onwer;

    public void SetMaxHealth()
    {
        maxHealth = currentHealth = _onwer.Stat.maxHp;
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        OnHit?.Invoke();
        Mathf.Clamp(currentHealth, 0, maxHealth);

        if(Mathf.Approximately(currentHealth, 0))
        {
            OnDead?.Invoke();
        }
    }
}
