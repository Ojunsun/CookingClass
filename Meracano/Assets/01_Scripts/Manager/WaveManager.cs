using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    public WaveSO Waves;
    private int currentWaveCnt = 0;

    public int Height { get; private set; } = 3;
    public int Width { get; private set; }

    private float space;

    public float StartPosY { get; private set; } = 3.9f;

    private void Start()
    {
        Width = SpawnManager.Instance.Width;
        space = SpawnManager.Instance.Space;

        SetEnemy();
    }

    public void BattleStartEventHandler() //버튼 이벤트 실행시 사용될 함수
    {
        Debug.Log("실행");
        EventManager.OnBattleStartEvent?.Invoke();
    }

    // BattleEnd 되면 실행
    public void SetEnemy()
    {
        float startPosX = (Width - 1) * -space / 2;

        for (int i = 0; i < Height; ++i)
        {
            for (int j = 0; j < Width; ++j)
            {
                PositionPrefab positionPrefab = PoolManager.Instance.Pop("EnemyPosition") as PositionPrefab;
                positionPrefab.SetTransform(startPosX + j * space, StartPosY - i * space);

                Waves.StageList[currentWaveCnt].EnemyList.ForEach(e =>
                {
                    if(e.x == j && e.y == i)
                    {
                        Enemy enemy = PoolManager.Instance.Pop($"{e.enemyPref.name}") as Enemy;
                        positionPrefab.SetEntity(enemy);
                    }
                });

            }
        }
    }
}
