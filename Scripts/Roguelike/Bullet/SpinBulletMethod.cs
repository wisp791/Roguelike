using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBulletMethod : BulletMethod
{
    public override void Method(Bullet bullet)
    {
        bullet.transform.Rotate(0, 0, 180f * Time.deltaTime);
    }
}
