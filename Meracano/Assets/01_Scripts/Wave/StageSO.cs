using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyArrangementClass
{
    [Header("Àû ÇÁ¸®ÆÕ")]
    public Enemy enemyPref;
    
    [Header("ÁÂÇ¥")]
    [Range(0,4)]
    public int x;
    [Range(0,2)]
    public int y;
}
[CreateAssetMenu(menuName = "SO/Wave/Stage")]
public class StageSO : ScriptableObject
{
    public List<EnemyArrangementClass> EnemyList;
}
