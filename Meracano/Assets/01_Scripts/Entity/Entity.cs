using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Entity : PoolableMono
{
    public Entity Target;
    public LayerMask TargetLayer;

    public bool IsBattle = false;
    public bool DoAttack = false;
    public bool IsDead = false;
    public bool IsAddedToBattle = false;

    private float speed = 5;

    private int _maxDetectEnemy = 5;
    private Collider2D[] _targetColliders;

    [field:SerializeField] public EntityStatSO Stat { get; protected set; }

    public int Level => Stat.Level;

    #region ������Ʈ
    public DamageCaster DamageCasterCompo { get; protected set; }
    public Health HealthCompo { get; protected set; }
    #endregion

    protected virtual void Awake()
    {
        DamageCasterCompo = GetComponentInChildren<DamageCaster>();
        HealthCompo = GetComponent<Health>();

        HealthCompo?.SetMaxHealth(Stat.MaxHP);

        _targetColliders = new Collider2D[_maxDetectEnemy];

        EventManager.OnBattleEndEvent += OnSettingHandler;
    }

    private void OnSettingHandler()
    {
        IsBattle = false;
        DoAttack = false;
    }
    
    public T FindNearestTarget<T>(float checkRange, LayerMask mask) where T : Entity
    {
        T target = null;

        float maxDistance = 300f;

        int count = Physics2D.OverlapCircleNonAlloc(transform.position, checkRange, _targetColliders, mask);

        for (int i = 0; i < count; ++i)
        {
            Collider2D collider = _targetColliders[i];
            if (collider.TryGetComponent(out T potentialTarget))
            {
                float distanceToTarget = Vector3.Distance(transform.position, potentialTarget.transform.position);

                if (distanceToTarget < maxDistance)
                {
                    target = potentialTarget;
                    maxDistance = distanceToTarget;
                }
            }
        }
        return target;
    }

    public override void Init()
    {
        HealthCompo.SetMaxHealth(Stat.MaxHP);
        IsDead = false;
        IsAddedToBattle = false;
    }

    public void SetTransform(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
