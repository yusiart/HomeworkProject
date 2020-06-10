using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransitionRapprochement : Transition
{
    [SerializeField] private float _transitionRanget;
    [SerializeField] private float _rangedSpreat;

    private void Start()
    {
        _transitionRanget += Random.Range(-_rangedSpreat, _rangedSpreat);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _transitionRanget)
        {
            NeedTransit = true;
        }
    }
}