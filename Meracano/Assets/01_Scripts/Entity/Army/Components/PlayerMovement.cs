using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private Entity _target;
    private PlayerAttack _playerAttack;

    public bool DoAttack = false;

    public void Initialize(Player player)
    {
        _player = player;
        _playerAttack = player.GetCompo<PlayerAttack>();
    }

    public void MoveToTargetPos(Transform _targetPos)
    {
        var targetDis = _player.Stat.AttackDistance;

        float distanceToTarget = Vector3.Distance(transform.position, _targetPos.position);

        if (distanceToTarget <= targetDis)
        {
            DoAttack = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, _player.Stat.MoveSpeed * Time.deltaTime);
        }
    }
}
