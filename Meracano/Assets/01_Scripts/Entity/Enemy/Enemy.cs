using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Enemy : Entity
{
    public EnemyStateMachine StateMachine { get; private set; }
    private Dictionary<Type, IEnemyComponent> _components;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();
        _components = new Dictionary<Type, IEnemyComponent>();
        GetComponentsInChildren<IEnemyComponent>().ToList().ForEach(compo => _components.Add(compo.GetType(), compo));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
    }

    private void OnEnable()
    {
        EventManager.OnBattleStartEvent += OnBattleStartEventHandler;
        EventManager.OnBattleEndEvent += OnBattleEndEventHandler;
    }

    private void OnDisable()
    {
        EventManager.OnBattleStartEvent -= OnBattleStartEventHandler;
        EventManager.OnBattleEndEvent -= OnBattleEndEventHandler;
    }

    private void Update()
    {
        if (StateMachine.currentState != null)
            StateMachine.UpdateMachine();
    }

    private void OnBattleStartEventHandler()
    {
        IsBattle = true;

        // 전투 시작 시에만 리스트에 추가
        if (!IsAddedToBattle)
        {
            BattleManager.Instance.AddList(this, false);
            IsAddedToBattle = true;
        }
    }

    private void OnBattleEndEventHandler()
    {
        IsBattle = false;
    }

    public T GetCompo<T>() where T : class
    {
        if(_components.TryGetValue(typeof(T), out IEnemyComponent compo))
        {
            return compo as T;
        }
        return default;
    }

    public abstract EnemyState GetState(Enum enumType);

}
