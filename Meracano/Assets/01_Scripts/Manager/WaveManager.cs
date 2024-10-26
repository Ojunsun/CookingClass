using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : Singleton<WaveManager>
{
    public WaveSO Waves;
    private int currentWaveCnt = 0;

    private void Start()
    {
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
        int height = 3;
        int width = 4;

        float startPosX = -1.8f;
        float startPosY = 3.9f;

        for (int i = 0; i < height; ++i)
        {
            for (int j = 0; j < width; ++j)
            {
                PositionPrefab positionPrefab = PoolManager.Instance.Pop("EnemyPosition") as PositionPrefab;
                positionPrefab.SetTransform(startPosX + j * 1.2f, startPosY - i * 1.3f);

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
