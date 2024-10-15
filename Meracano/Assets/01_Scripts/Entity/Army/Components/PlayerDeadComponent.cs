using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadComponent : MonoBehaviour, IPlayerComponent
{
    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void Start()
    {
        _player.HealthCompo.OnDead += OnDeadHandler;
    }

    private void OnDeadHandler()
    {
        //Á×À½ Ã³¸®
        Debug.Log(gameObject.name + "´Â »ç¸ÁÇß´Ù.");
    }
}
