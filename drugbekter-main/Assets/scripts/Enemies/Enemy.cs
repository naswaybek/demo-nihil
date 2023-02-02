using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] private int _maxHealth = 20;
    [SerializeField] private int _health;

    [SerializeField] private int _damage = 1;

    [Header("References")]
    [SerializeField] private Image _healthFill;

    private AIDestinationSetter _destinationSetter;

    private Player _player;

    private void Start()
    {
        _destinationSetter = GetComponent<AIDestinationSetter>();

        _player = Player.Instance;

        _destinationSetter.target = _player.transform;

        _health = _maxHealth;

    }


    public void TakeDamage(int damage)
    {
        _health -= damage;
        _healthFill.fillAmount = (float)_health / _maxHealth;
        if (_health <= 0)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            player.TakeDamage(_damage);
        }
    }


}
