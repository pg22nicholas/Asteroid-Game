using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectile : HomingProjectile
{
    [SerializeField] private float m_explosionRadius = 5f;

    // Destroy all asteroids within explosion radius of projectile
    public override void OnHitAsteroid() {
        base.OnHitAsteroid();

        //Collider[] asteroidsInExplosion = GetAsteroidsInExplosion();
        //foreach (Collider asteroidCollider in asteroidsInExplosion) {
        //    Destroy(asteroidCollider.gameObject);
        //}
    }
    
    Collider[] GetAsteroidsInExplosion() {
        return Physics.OverlapSphere(transform.position, m_explosionRadius, m_targetLayerMask);
    }
}
