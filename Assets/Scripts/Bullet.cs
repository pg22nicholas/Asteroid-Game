using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{

    public virtual void OnHitAsteroid() {
        //Score.AddScore(1);
        //Destroy(gameObject);
    }
}
