using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SpiralBulletMethod : BulletMethod
{
    public override void Method(Bullet bullet)
    {
        bullet.transform.position = new UnityEngine.Vector2(Mathf.Cos(Time.time) * Time.time, Mathf.Sin(Time.time) * Time.time);
    }
}
