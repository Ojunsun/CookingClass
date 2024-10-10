using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnEnable()
    {
        EventManager.OnBattleStartEvent += OnBattleStartEventHandler;
    }

    private void OnBattleStartEventHandler()
    {
        _target = _player.FindNearestTarget<Entity>(50f, _player.TargetLayer);

        MoveToTargetPos(_target.transform);
    }

    public void MoveToTargetPos(Transform _targetPos)
    {
        StartCoroutine(MoveToTarget(_targetPos));
    }

    private IEnumerator MoveToTarget(Transform _targetPos)
    {
        var targetDis = _player.Stat.attackDistance;

        while (true)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _targetPos.position);

            if (distanceToTarget <= targetDis)
            {
                _playerAttack.AttackTarget();
                yield break;
            }

            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, _player.Stat.moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
