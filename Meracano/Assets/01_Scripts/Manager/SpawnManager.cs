using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public EntitySO PlayerSO;
    private List<PositionPrefab> posList;

    public int Height { get; private set; } = 4;
    public int Width { get; private set; } = 5;

    public float Space { get; private set; } = 0.9f;

    private void Awake()
    {
        posList = new List<PositionPrefab>();
    }

    private void Start()
    {
        SetPositions();
    }

    private void SetPositions()
    {
        float startPosX = (Width - 1) * -Space / 2;
        float startPosY = (WaveManager.Instance.StartPosY) - (Space * WaveManager.Instance.Height);

        for (int y = 0; y < Height; ++y)
        {
            for (int x = 0; x < Width; ++x)
            {
                PositionPrefab positionPrefab = PoolManager.Instance.Pop("PlayerPosition") as PositionPrefab;
                posList.Add(positionPrefab);

                positionPrefab.SetTransform(startPosX + x * Space, startPosY - y * Space);
            }
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

    public void SpawnPlayer()
    {
        PositionPrefab closestPositionPref = FindClosestPosition();

        if(closestPositionPref == null)
        {
            Debug.Log("no more position to spawn Players");
            return;
        }

        Player newPlayer = PoolManager.Instance.Pop(FindEntityLevel(1)?.name) as Player;
        closestPositionPref.SetEntity(newPlayer);
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

            firstPointed.SetEntity(player2);
            lastPointed.SetEntity(player1);

            return;
        }

        Player newPlayer = PoolManager.Instance.Pop(FindEntityLevel(player1.Level + 1).name) as Player;
        lastPointed.SetEntity(newPlayer);

        PoolManager.Instance.Push(player1);
        PoolManager.Instance.Push(player2);
    }
}
