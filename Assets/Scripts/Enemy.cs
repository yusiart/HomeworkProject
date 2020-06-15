using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _reward;
    [SerializeField] private int _healthCount;

    private int _health;
    private Player _target;

    public Player Target
    {
        get => _target;
    }

    private void OnEnable()
    {
        _health = _healthCount;
    }

    private void Start()
    {
        _target = FindObjectOfType<Player>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            _target.ApplyReward(_reward);
            gameObject.SetActive(false);
        }
    }
}