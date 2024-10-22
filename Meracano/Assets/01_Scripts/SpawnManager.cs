using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        return posList.FirstOrDefault(pos => pos.transform.GetComponentInChildren<Player>() == null);
    }

    public Entity FindEntityLevel(int level)
    {
        return PlayerSO.Entities.FirstOrDefault(entity => entity.Level == level);
    }

    private void SpawnPlayer()
    {
        PositionPrefab closestPositionPref = FindClosestPosition();

        if(closestPositionPref == null)
        {
            Debug.Log("no more position to spawn Players");
            return;
        }

        Player newPlayer = PoolManager.Instance.Pop(FindEntityLevel(1)?.name) as Player;
        closestPositionPref.SetPlayer(newPlayer);
    }

    public void FindCanMergePlayer(Player player) // 레벨 같은 거 찾아주는 함수
    {
        int level = player.Level;
        
        foreach(PositionPrefab posPrefab in posList)
        {
            Player p = posPrefab.GetComponentInChildren<Player>();
            if (p != null && p != player && p.Level == level)
            {
                posPrefab.EnterCanMerge();
            }
        }
    }

    public void ResetDrag()
    {
        posList.ForEach(p => p.ExitCanMerge());
    }

    public void MergePlayer(Player player1, Player player2, PositionPrefab firstPointed, PositionPrefab lastPointed)
    {
        if (player1.Level != player2.Level || FindEntityLevel(player1.Level + 1) == null)
        {
            Debug.Log("Level is Different || Max Level");

            firstPointed.SetPlayer(player2);
            lastPointed.SetPlayer(player1);
            return;
        }

        Player newPlayer = PoolManager.Instance.Pop(FindEntityLevel(player1.Level + 1).name) as Player;
        lastPointed.SetPlayer(newPlayer);

        PoolManager.Instance.Push(player1);
        PoolManager.Instance.Push(player2);
    }
}
