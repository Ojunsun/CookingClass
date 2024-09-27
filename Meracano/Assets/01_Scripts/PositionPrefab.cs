using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrefab : PoolableMono
{
    // player
    public override void Init()
    {
        transform.position = Vector3.zero;
    }

    public void SetTransform(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
    }

    private void OnMouseEnter()
    {
        print(transform.position);
    }

    private void OnMouseExit()
    {

    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUp()
    {
        
    }
}   
