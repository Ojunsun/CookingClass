using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private DamageCaster _damageCasterCompo;
    private Rigidbody2D _rigid;

    private void Awake()
    {
        _damageCasterCompo = GetComponent<DamageCaster>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector3 dir)
    {
        StartCoroutine(RemoveArrow());

        _rigid.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    IEnumerator RemoveArrow()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == _damageCasterCompo._onwer.TargetLayer)
        {
            _damageCasterCompo.CastDamage();
        }
    }
}
