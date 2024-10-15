using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    [SerializeField] private int height = 7;
    [SerializeField] private int width = 5;

    private List<PositionPrefab> posList;

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
                PositionPrefab positionPrefab = PoolManager.Instance.Pop("PositionPrefab") as PositionPrefab;
                posList.Add(positionPrefab);

                positionPrefab.SetTransform(startPosX + j * 1.1f, startPosY - i * 1.3f);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CreatePlayer();
        }
    }

    public PositionPrefab FindClosestPosition()
    {
        foreach(var pos in posList)
        {
            if (pos.transform.GetComponentInChildren<Player>() == null)
            {
                return pos;
            }
        }

        return null;
    }

    private void CreatePlayer()
    {
        PositionPrefab closestPositionPref = FindClosestPosition();

        if(closestPositionPref == null)
        {
            Debug.Log("³¡");
        }
        else
        {
            Player newPlayerPrefab = PoolManager.Instance.Pop("Army") as Player;
            closestPositionPref.SetPlayer(newPlayerPrefab);
        }
    }
}
