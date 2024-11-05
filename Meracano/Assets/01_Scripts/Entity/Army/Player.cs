using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public abstract class Player : Entity
{
    public ArmyStateMachine StateMachine { get; private set; }
    private Dictionary<Type, IPlayerComponent> _components;
    private bool _isAddedToBattle = false;

    protected override void Awake()
    {
        base.Awake();

        StateMachine = new ArmyStateMachine();

        _components = new Dictionary<Type, IPlayerComponent>();
        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(compo => _components.Add(compo.GetType(), compo));

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
        if(StateMachine.currentState != null)
            StateMachine.UpdateMachine();
    }

    private void OnBattleStartEventHandler()
    {
        IsBattle = true;

        // 전투 시작 시에만 리스트에 추가
        if (!_isAddedToBattle)
        {
            BattleManager.Instance.AddList(this, true);
            _isAddedToBattle = true;
        }
    }

    private void OnBattleEndEventHandler()
    {
        IsBattle = false;
        
        if(_isAddedToBattle)
        {
            _isAddedToBattle = false;
        }
    }

    public T GetCompo<T>() where T : class
    {
        if (_components.TryGetValue(typeof(T), out IPlayerComponent compo))
        {
            return compo as T;
        }
        return default;
    }

    public abstract ArmyState GetState(Enum enumType);
}
