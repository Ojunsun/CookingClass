using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    private int height = 7;
    private int width = 5;

    [SerializeField] private PositionPrefab posPrefab;

    private void Start()
    {
        float startPosX = -2.2f;
        float startPosY = 3.9f;

        for(int i = 0; i < height; ++i)
        {
            for(int j = 0; j < width; ++j)
            {
                PositionPrefab pref = PoolManager.Instance.Pop("PositionPrefab") as PositionPrefab;

                pref.transform.SetParent(this.transform);
                pref.SetTransform(startPosX + j * 1.1f, startPosY - i * 1.3f);
            }
        }        
    }
}
