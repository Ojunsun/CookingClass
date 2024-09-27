using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private int _maxDetectEnemy = 5;
    private Collider2D[] _targetColliders;

    private void Awake()
    {
        _targetColliders = new Collider2D[_maxDetectEnemy];
    }

    public void MoveToTargetPos(Transform _targetPos)
    {
        
    }

    public void AttackTarget(Entity _target)
    {

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
