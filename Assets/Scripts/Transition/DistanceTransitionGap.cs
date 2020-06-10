using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransitionGap : Transition
{
    [SerializeField] private float _transitionRanged;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) > _transitionRanged)
        {
            NeedTransit = true;
        }
    }
}