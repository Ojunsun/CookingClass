using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoSingleton<WaveManager>
{
    public WaveSO Waves;
    private int currentWaveCnt = 0;

    public int Height { get; private set; } = 3;
    public int Width { get; private set; }

    private float space;

    public float StartPosY { get; private set; } = 3.9f;

    private List<PositionPrefab> enemyPositionList = new List<PositionPrefab>();

    private void Start()
    {
        Width = SpawnManager.Instance.Width;
        space = SpawnManager.Instance.Space;
        EventManager.OnVictoryEvent += OnVictoryEventHandler;

        SetEnemyPosition();
    }

    public void BattleStartEventHandler() //버튼 이벤트 실행시 사용될 함수
    {
        EventManager.OnBattleStartEvent?.Invoke();
    }

    private void OnVictoryEventHandler()
    {
        currentWaveCnt++;
    }

    // BattleEnd 되면 실행
    public void SetEnemyPosition()
    {
        float startPosX = (Width - 1) * -space / 2;

        for (int y = 0; y < Height; ++y)
        {
            for (int x = 0; x < Width; ++x)
            {
                PositionPrefab positionPrefab = PoolManager.Instance.Pop("EnemyPosition") as PositionPrefab;
                positionPrefab.SetTransform(startPosX + x * space, StartPosY - y * space);

                enemyPositionList.Add(positionPrefab);
            }
        }

        SetEnemy();
    }

    public void SetEnemy()
    {
        Dictionary<(int x, int y), Enemy> findEnemyDictionary = new Dictionary<(int, int), Enemy>();
        Waves.StageList[currentWaveCnt].EnemyList.ForEach(e =>
        {
            findEnemyDictionary[(e.x, e.y)] = e.enemyPref;
        });

        int cnt = 0;

        for (int y = 0; y < Height; ++y)
        {
            for (int x = 0; x < Width; ++x)
            {
                if (findEnemyDictionary.TryGetValue((x, y), out Enemy findEnemy))
                {
                    Enemy enemy = PoolManager.Instance.Pop($"{findEnemy.name}") as Enemy;
                    enemyPositionList[cnt].SetEntity(enemy);
                }

                cnt++;
            }
        }
    }
}
