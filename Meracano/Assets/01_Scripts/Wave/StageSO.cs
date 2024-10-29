using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyArrangementClass
{
    [Header("Àû ÇÁ¸®ÆÕ")]
    public Enemy enemyPref;
    
    [Header("ÁÂÇ¥")]
    public int x;
    public int y;
}
[CreateAssetMenu(menuName = "SO/Wave/Stage")]
public class StageSO : ScriptableObject
{
    public List<EnemyArrangementClass> EnemyList;

    private void OnValidate()
    {
        foreach (var enemyArrangement in EnemyList)
        {
            if (enemyArrangement.x < 0 || enemyArrangement.x >= SpawnManager.Instance.Width - 1)
            {
                Debug.LogWarning($"{enemyArrangement.x}, X ÁÂÇ¥ È®ÀÎ");
            }

            if (enemyArrangement.y < 0 || enemyArrangement.y >= WaveManager.Instance.Height - 1)
            {
                Debug.LogWarning($"{enemyArrangement.y}, Y ÁÂÇ¥ È®ÀÎ");
            }
        }
    }
}
