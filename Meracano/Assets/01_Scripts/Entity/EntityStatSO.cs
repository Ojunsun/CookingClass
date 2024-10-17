using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Entity/Stat")]
public class EntityStatSO : ScriptableObject
{
    // common epic hero legend  
    [Header("Level")]
    public int Level;

    [Header("Stat")]
    public float MaxHP;
    public float Damage;
    public float MoveSpeed;
    public float AttackDistance;
}
    