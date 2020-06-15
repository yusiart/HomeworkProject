using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _maxLifeTime;

    private Vector2 _bulletDirection;
    private float _activeTime;


    private void Update()
    {
        _activeTime += Time.deltaTime;
        transform.Translate(_bulletDirection * (_speed * Time.deltaTime), Space.Self);

        if (_activeTime > _maxLifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 bulletDirection)
    {
        _bulletDirection = bulletDirection;
    }
}
