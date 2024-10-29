using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttackComponent : MonoBehaviour, IPlayerComponent
{
    [SerializeField]
    private Arrow _arrow;
    private Player _player;
    
    public void Initialize(Player player)
    {
        _player = player;
    }

    public void RangeAttack()
    {
        Instantiate(_arrow);

        var target = _player.FindNearestTarget<Entity>(_player.Stat.AttackDistance, _player.TargetLayer);
        Vector2 dir = transform.position - target.transform.position;

        _arrow.Fire(dir);
    }
}
