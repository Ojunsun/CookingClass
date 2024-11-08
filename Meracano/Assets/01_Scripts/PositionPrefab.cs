using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrefab : PoolableMono
{
    public bool IsPlayerPos;

    private SpriteRenderer sr;
    //private SpriteRenderer backGroundSr;
    private GameObject outlineSr;

    public Entity PositionEntity { get; private set; }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        outlineSr = transform.GetChild(0).gameObject;
    }

    // player
    public override void Init()
    {
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one * 0.7f;

        sr.color = Color.white;
        outlineSr.SetActive(false);
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
        if (IsPlayerPos) outlineSr.SetActive(true);
    }
    public void MouseExit()
    {
        if (IsPlayerPos) outlineSr.SetActive(false);
    }

    public void EnterCanMerge()
    {
        if (IsPlayerPos) sr.color = Color.red;
    }
    public void ExitCanMerge()
    {
        if(IsPlayerPos) sr.color = Color.white;
    }
}   
