using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    private int height = 7;
    private int width = 5;

    private List<PositionPrefab> posList;

    private int minCnt = 0;
    private int curCnt = 0;
    private int maxCnt = 0;

    private void Awake()
    {
        posList = new List<PositionPrefab>();
    }

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
                posList.Add(pref);

                pref.SetTransform(startPosX + j * 1.1f, startPosY - i * 1.3f);
            }
        }

        maxCnt = posList.Count;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        Player pref = PoolManager.Instance.Pop("Army") as Player;
        posList[curCnt++].SetPlayer(pref);
    }
}
