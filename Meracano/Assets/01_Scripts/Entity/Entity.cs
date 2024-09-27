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

    protected virtual void Awake()
    {
        _targetColliders = new Collider2D[_maxDetectEnemy];
        Debug.Log($"_targetColliders initialized with size: {_targetColliders.Length}");
    }

    public void MoveToTargetPos(Transform _targetPos)
    {
        StartCoroutine(MoveToTarget(_targetPos));
    }

    private IEnumerator MoveToTarget(Transform _targetPos)
    {
        while (transform.position != _targetPos.position)
        {
            // MoveTowards를 사용하여 일정 속도로 목표 위치로 이동
            transform.position = Vector2.MoveTowards(transform.position, _targetPos.position, speed * Time.deltaTime);
            yield return null;
        }
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
