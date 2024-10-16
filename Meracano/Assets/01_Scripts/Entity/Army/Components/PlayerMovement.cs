using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private Entity _target;
    private PlayerAttackComponent _playerAttack;

    public bool DoAttack = false;

    public void Initialize(Player player)
    {
        _player = player;
        _playerAttack = player.GetCompo<PlayerAttackComponent>();
    }

    public void MoveToTargetPos(Transform _targetPos)
    {
        StartCoroutine(MoveToTarget(_targetPos));
    }

    private IEnumerator MoveToTarget(Transform _targetPos)
    {
        var targetDis = _player.Stat.AttackDistance;

        while (true)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _targetPos.position);

            if (distanceToTarget <= targetDis)
            {
                DoAttack = true;
                yield break;
            }

            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, _player.Stat.MoveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
