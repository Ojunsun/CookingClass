using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackComponent : MonoBehaviour, IPlayerComponent
{
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }

    public void AttackTarget()
    {
        _player.DamageCasterCompo.CastMeleeDamage();
    }
}
