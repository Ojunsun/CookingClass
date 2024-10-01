using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private Entity _target;

    public void Initialize(Player player)
    {
        _player = player;
    }

    private void OnEnable()
    {
        EventManager.OnBattleStartEvent += OnBattleStartEventHandler;
    }

    private void OnBattleStartEventHandler()
    {
        _target = _player.FindNearestTarget<Entity>(50f, _player.TargetLayer);

        _player.MoveToTargetPos(_target.transform);
    }
}
