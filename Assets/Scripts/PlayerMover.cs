using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpAcceleration;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _groundCheck;

    private Animator _animator;
    private bool _isGrounded = false;
    private Rigidbody2D _rigidbody;
    private bool _isRightSide = true;
    private float groundRadius = 0.2f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        float move = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(move * _speed, _rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }

        if ((move > 0f && !_isRightSide) || (move < 0f && _isRightSide))
        {
            Spin();
        }

        if ((move > 0f && !_isRightSide) || (move < 0f && _isRightSide))
        {
            Spin();
        }

        if (move > 0 || move < 0)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }

    private void Jump()
    {
        _isGrounded = false;
        _rigidbody.AddForce(new Vector3(0, _jumpAcceleration));
    }


    private void Spin()
    {
        _isRightSide = !_isRightSide;
        transform.Rotate(0f, 180f, 0f);
    }

    private void CheckGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, groundRadius, _whatIsGround);

        if (!_isGrounded)
            return;
    }
}
