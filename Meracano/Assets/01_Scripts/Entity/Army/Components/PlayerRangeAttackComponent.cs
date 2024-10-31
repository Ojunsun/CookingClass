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
        Arrow newArrow = Instantiate(_arrow, transform.position, Quaternion.identity);

        var target = _player.FindNearestTarget<Entity>(_player.Stat.AttackDistance, _player.TargetLayer);
        Vector2 dir = (target.transform.position - transform.position).normalized;

        var damage = _player.Stat.Damage;

        newArrow.SetDamage(damage);
        newArrow.Fire(dir);
    }
}
