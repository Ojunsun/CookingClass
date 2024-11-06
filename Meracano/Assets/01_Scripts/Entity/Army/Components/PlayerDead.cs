using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour, IPlayerComponent
{
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void OnEnable()
    {
        _player.HealthCompo.OnDead += OnDeadHandler;
    }

    private void OnDisable()
    {
        _player.HealthCompo.OnDead -= OnDeadHandler;
    }

    private void OnDeadHandler()
    {
        //���� ó��
        Debug.Log(gameObject.name + "�� ����ߴ�.");
        _player.IsDead = true;

        PoolManager.Instance.Push(_player);
    }
}
