using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrefab : PoolableMono
{
    [SerializeField] private bool IsPlayerPos;

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
        transform.localScale = Vector3.one * 0.7f;
    }

    public void SetEntity(Entity e)
    {
        e.SetTransform(transform);
    }

    public void SetTransform(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
    }

    public void MouseEnter()
    {
        if (IsPlayerPos) sr.color = Color.red;
    }
    public void MouseExit()
    {
        if (IsPlayerPos) sr.color = Color.white;
    }

    public void EnterCanMerge()
    {
        if(IsPlayerPos) backGroundSr.color = Color.yellow;
    }
    public void ExitCanMerge()
    {
        if(IsPlayerPos) backGroundSr.color = Color.white;
    }
}   
