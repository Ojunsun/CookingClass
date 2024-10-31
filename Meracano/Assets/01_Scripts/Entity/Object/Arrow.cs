using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Arrow : PoolableMono
{
    [SerializeField]
    private float speed;
    private float _damage;

    private DamageCaster _damageCasterCompo;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _damageCasterCompo = GetComponent<DamageCaster>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void Fire(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        _rigid.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((1 << other.gameObject.layer & _damageCasterCompo.TargetLayer) != 0)
        {
            _damageCasterCompo.CastDamage(_damage);

            PoolManager.Instance.Push(this);
        }
    }

    public override void Init()
    {

    }
}
