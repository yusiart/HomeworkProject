using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Weapoon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected float _bulletSpeed = 10;

    public abstract void Shoot(Transform shootPoint, Vector2 bulletDirection);
}
