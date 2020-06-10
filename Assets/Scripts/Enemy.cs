using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;

    private void Start()
    {
        _target = FindObjectOfType<Player>();
    }

    public Player Target
    {
        get => _target;
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