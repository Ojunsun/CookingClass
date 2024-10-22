using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour, IPlayerComponent
{
    private Player _player;
    public Animator Anim { get; private set; }

    public void Initialize(Player player)
    {
        _player = player;
        Anim = player.GetCompo<Animator>();
    }
}
