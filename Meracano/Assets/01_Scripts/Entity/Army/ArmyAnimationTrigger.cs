using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class ArmyAnimationTrigger : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    private PlayerAttack _attackCompo;
    private PlayerRangeAttackComponent _rangeAttackCompo;

    public void Initialize(Player player)
    {
        _player = player;
        _attackCompo = player.GetCompo<PlayerAttack>();
        _rangeAttackCompo = player.GetCompo<PlayerRangeAttackComponent>();
    }

    public void AttackTrigger()
    {
        _attackCompo.AttackTarget();
    }

    public void RangeAttackTrigger()
    {
        _rangeAttackCompo.RangeAttack();
    }
}
