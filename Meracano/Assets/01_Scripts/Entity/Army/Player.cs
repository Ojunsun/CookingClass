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
    }
    private void OnBattleStartEventHandler()
    {
        IsBattle = true;
    }

    public T GetCompo<T>() where T : class
    {
        if (_components.TryGetValue(typeof(T), out IPlayerComponent compo))
        {
            return compo as T;
        }
        return default;
    }

    public void SetTransform(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
    }

    public void Upgrade()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = UnityEngine.Random.ColorHSV();
    }

    public abstract ArmyState GetState(Enum enumType);
}
