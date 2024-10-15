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
