using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrefab : PoolableMono
{
    private Player curPlayer;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // player
    public override void Init()
    {
        curPlayer = null;
        transform.localPosition = Vector3.zero;
    }

    public void SetPlayer(Player p)
    {
        curPlayer = p;
        curPlayer.SetTransform(transform);
    }

    public void SetTransform(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
    }

    public void MouseEnter()
    {
        sr.color = Color.red;
    }
    public void MouseExit()
    {
        sr.color = Color.white;
    }
}   
