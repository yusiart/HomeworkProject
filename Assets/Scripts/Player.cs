using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Weapoon _weapoon;
    [SerializeField] protected Transform _shootPooint;

    private int _gold;
    private Vector2 _bulletDirection;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> GoldChanged;

    private void Start()
    {
        GoldChanged?.Invoke(_gold);
        HealthChanged?.Invoke(_health);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetBulletDirection(ref _bulletDirection);
            _weapoon.Shoot(_shootPooint, _bulletDirection);
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void ApplyReward(int gold)
    {
        _gold += gold;
        GoldChanged?.Invoke(_gold);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void SetBulletDirection(ref Vector2 bulletDirection)
    {
        float xBulletPosition = _shootPooint.transform.position.x - transform.position.x;
        bulletDirection = new Vector2(xBulletPosition, 0);
    }
}