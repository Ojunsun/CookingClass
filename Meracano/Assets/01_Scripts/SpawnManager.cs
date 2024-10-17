using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public EntitySO PlayerSO;

    private int height = 7;
    private int width = 5;

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
            SpawnPlayer();
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

    public void SpawnPlayer(int num = 0)
    {
        PositionPrefab closestPositionPref = FindClosestPosition();

        if(closestPositionPref == null)
        {
            Debug.Log("no more position to spawn Players");
            return;
        }

        Player newPlayer = PoolManager.Instance.Pop(PlayerSO.Entities[num].name) as Player;
        closestPositionPref.SetPlayer(newPlayer);
    }



    public void FindCanMergePlayer(Player player) // 레벨 같은 거 찾아주는 함수
    {
        //int level = player.Level;
        //
        //foreach(var pos in posList)
        //{
        //    if(pos.transform.TryGetComponent<Player>(out Player p))
        //    {
        //        if(p != player && p.Level == player.Level)
        //        {
        //
        //        }
        //    }
        //}
    }

    public void MergePlayer(Player player1, Player player2, PositionPrefab firstPointed, PositionPrefab lastPointed)
    {
        if (player1.Level != player2.Level || player1.Level >= PlayerSO.Entities.Count)
        {
            Debug.Log("Level is Different || Max Level");

            firstPointed.SetPlayer(player2);
            lastPointed.SetPlayer(player1);
            return;
        }

        Player newPlayer = PoolManager.Instance.Pop(PlayerSO.Entities[player1.Level].name) as Player;
        lastPointed.SetPlayer(newPlayer);

        PoolManager.Instance.Push(player1);
        PoolManager.Instance.Push(player2);
    }
}
