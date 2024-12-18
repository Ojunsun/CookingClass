using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IPlayerComponent
{
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }

    public void AttackTarget()
    {
        var damage = _player.Stat.Damage;
        _player.DamageCasterCompo.CastDamage(damage);
    }
}
