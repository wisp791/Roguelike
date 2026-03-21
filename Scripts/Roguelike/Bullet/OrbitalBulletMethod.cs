using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalBulletMethod : BulletMethod
{
    public float orbitDistance = 3f;
    public float rotationSpeed = 50f;

    public override void Method(Bullet bullet)
    {
        bullet.transform.position = bullet.playerTransform.position +
            (bullet.transform.position - bullet.playerTransform.position).normalized * orbitDistance;

        bullet.transform.RotateAround(bullet.playerTransform.position, Vector3.forward,
            bullet.bulletData.bulletSpeed * Time.deltaTime);
        
        bullet.transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
    }
}
