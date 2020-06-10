﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;
    protected Player Target { get; private set; }

    public bool NeedTransit { get; protected set; }


    public State TargetState
    {
        get => _targetState;
        private set => _targetState = value;
    }

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
