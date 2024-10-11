using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : Entity
{
    private Dictionary<Type, IPlayerComponent> _components;

    protected override void Awake()
    {
        base.Awake();
        _components = new Dictionary<Type, IPlayerComponent>();
        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(compo => _components.Add(compo.GetType(), compo));

        _components.Values.ToList().ForEach(compo => compo.Initialize(this));
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
}
