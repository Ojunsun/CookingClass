using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BattleManager : MonoSingleton<BattleManager>
{
    [SerializeField] private List<Entity> players = new List<Entity>();
    [SerializeField] private List<Entity> enemies = new List<Entity>();

    private Dictionary<Entity, Action> onDeadSubscriptions = new Dictionary<Entity, Action>();

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

        if (health != null)
        {
            Action onDeadAction = () => RemoveList(entity, isArmy);
            health.OnDead += onDeadAction;
            onDeadSubscriptions[entity] = onDeadAction;  
        }
    }

    public void RemoveList(Entity entity, bool isArmy)
    {
        // ���� ���� ����
        if (onDeadSubscriptions.TryGetValue(entity, out Action onDeadAction))
        {
            Health health = entity.GetComponent<Health>();
            if (health != null)
            {
                health.OnDead -= onDeadAction; // �̺�Ʈ ���� ����
            }
            onDeadSubscriptions.Remove(entity); // ��ųʸ����� ����
        }

        if (isArmy)
        {
            players.Remove(entity);

            if (players.Count <= 0)
                StartCoroutine(BattleLose());
        }
        else
        {
            enemies.Remove(entity);

            if (enemies.Count <= 0)
                StartCoroutine(BattleWin());
        }
    }

    IEnumerator BattleWin()
    {
        players.ForEach(p => p.IsBattle = false);

        yield return new WaitForSeconds(1f);

        EventManager.OnBattleEndEvent?.Invoke();
        EventManager.OnVictoryEvent?.Invoke();
    }

    IEnumerator BattleLose()
    {
        enemies.ForEach(e => e.IsBattle = false);

        yield return new WaitForSeconds(1f);

        EventManager.OnBattleEndEvent?.Invoke();
        EventManager.OnGameOverEvent?.Invoke();
    }

    public void FindPlayerPosition()
    {
        players.ForEach(p => p.SetTransform(p.transform.parent));
    }
}