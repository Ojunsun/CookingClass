using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BattleManager : MonoSingleton<BattleManager>
{
    [SerializeField] private List<Entity> players = new List<Entity>();
    [SerializeField] private List<Entity> enemies = new List<Entity>();

    public void AddList(Entity entity, bool isArmy)
    {
        if(isArmy)
        {
            players.Add(entity);
        }
        else
        {
            enemies.Add(entity);
        }

        Health health = entity.GetComponent<Health>();
        
        if(health != null )
        {
            health.OnDead += () => RemoveList(entity, isArmy);
        }
    }

    public void RemoveList(Entity entity, bool isArmy)
    {
        if(isArmy)
        {
            players.Remove(entity);
        }
        else
        {
            enemies.Remove(entity);
        }

        CheckBattleEnd();
    }

    private void CheckBattleEnd()
    {
        if(enemies.Count <= 0)
        {
            EventManager.OnBattleEndEvent?.Invoke();
            EventManager.OnVictoryEvent?.Invoke();
        }
        else if(players.Count <= 0)
        {
            EventManager.OnBattleEndEvent?.Invoke();
            EventManager.OnGameOverEvent?.Invoke();
        }
    }
}