using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private Entity _target;
    private PlayerAttack _playerAttack;

    public void Initialize(Player player)
    {
        _player = player;
        _playerAttack = player.GetCompo<PlayerAttack>();
    }

    public void MoveToTargetPos(Transform _targetTrm)
    {
        var targetDis = _player.Stat.AttackDistance;

        float distanceToTarget = Vector3.Distance(transform.position, _targetTrm.position);

        if (distanceToTarget <= targetDis)
        {
            _player.DoAttack = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _targetTrm.position, _player.Stat.MoveSpeed * Time.deltaTime);
        }
    }

    public void LookTarget(Transform _targetTrm)
    {
        Vector2 direction = _targetTrm.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
