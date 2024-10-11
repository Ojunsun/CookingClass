using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public event Action OnHit;
    public event Action OnDead;

    public void SetMaxHealth(float _maxHealth)
    {
        maxHealth = currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;
        OnHit?.Invoke();
        Mathf.Clamp(currentHealth, 0, maxHealth);

        if(Mathf.Approximately(currentHealth, 0))
            OnDead?.Invoke();
    }
}
