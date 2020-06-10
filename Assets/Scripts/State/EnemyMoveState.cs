using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class EnemyMoveState : State
{
    [SerializeField] private float _speed;

    private SpriteRenderer _renderer;
    private Animator _animator;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _animator.SetBool("IsDistanceEnought",false);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);

        if (Target.transform.position.x > transform.position.x)
        {
            _renderer.flipX = false;
        }
        else
        {
            _renderer.flipX = true;
        }
    }
}
