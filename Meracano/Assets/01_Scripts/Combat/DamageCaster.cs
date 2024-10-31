using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DamageCaster : MonoBehaviour
{
    public LayerMask TargetLayer;
    [Range(0.5f, 3.0f)]
    public float _detectRange;

    public void CastDamage(float damage)
    {
        var coliders = Physics2D.OverlapCircleAll(transform.position, _detectRange, TargetLayer);

        if (coliders.Length <= 0)
            return;

        var target = coliders[0].GetComponent<Entity>();

        if (target != null)
        {
            target.HealthCompo.ApplyDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // 기즈모 색상 설정
        Gizmos.DrawWireSphere(transform.position, _detectRange); // 원형 기즈모 그리기
    }
}