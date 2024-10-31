using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DamageCaster : MonoBehaviour
{
    public LayerMask TargetLayer;
    [Range(1.0f, 3.0f)]
    public float _detectRange;

    public void CastDamage(float damage)
    {
        var coliders = Physics2D.OverlapCircleAll(transform.position, _detectRange, TargetLayer);

        if (coliders.Length <= 0)
            return;
        else
        {
            foreach(var colider in coliders)
            {
                var target = colider.GetComponent<Entity>();

                if(target != null)
                {
                    target.HealthCompo.ApplyDamage(damage); 
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red; // ����� ���� ����
        Gizmos.DrawWireSphere(transform.position, _detectRange); // ���� ����� �׸���
    }
}