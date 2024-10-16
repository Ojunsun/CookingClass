using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrefab : PoolableMono
{
    private SpriteRenderer sr;
    private SpriteRenderer backGroundSr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        backGroundSr = transform.Find("Ground").GetComponentInChildren<SpriteRenderer>();
    }

    // player
    public override void Init()
    {
        transform.localPosition = Vector3.zero;
    }

    public void SetPlayer(Player p)
    {
        p.SetTransform(transform);
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

    public void EnterCanMerge()
    {
        backGroundSr.color = Color.yellow;
    }
    public void ExitCanMerge()
    {
        backGroundSr.color = Color.white;
    }
}   
