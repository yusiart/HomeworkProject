using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : Weapoon
{
    public override void Shoot(Transform shootPooint, Vector2 bulletDirection)
    {
        var bullet = Instantiate(_bullet, shootPooint.position, Quaternion.identity);
        bullet.SetDirection(bulletDirection);
    }
}
