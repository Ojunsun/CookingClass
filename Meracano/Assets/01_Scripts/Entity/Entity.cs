using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public LayerMask TargetLayer;
    
    private float speed = 5;

    private int _maxDetectEnemy = 5;
    private Collider2D[] _targetColliders;

    [field:SerializeField] public EntityStatSO Stat { get; protected set; }

    #region ÄÄÆ÷³ÍÆ®
    public DamageCaster DamageCasterCompo { get; protected set; }
    public Health HealthCompo { get; protected set; }
    #endregion

    protected virtual void Awake()
    {
        DamageCasterCompo = GetComponentInChildren<DamageCaster>();
        HealthCompo = GetComponent<Health>();

        HealthCompo?.SetMaxHealth(Stat.maxHp);

        _targetColliders = new Collider2D[_maxDetectEnemy];
        Debug.Log($"_targetColliders initialized with size: {_targetColliders.Length}");
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
}
