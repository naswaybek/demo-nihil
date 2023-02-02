using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEfffect;

    private int _bulletDamage;

    public void Init(int damage, Vector2 direction)
    {
        _bulletDamage = damage;
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_bulletDamage);
        }

        GameObject effect = Instantiate(hitEfffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);
        Destroy(gameObject);
    }
}
