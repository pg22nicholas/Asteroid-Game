using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : Projectile
{
    [SerializeField] private int m_team = 0;
    [SerializeField] private float m_homingRadius = 5f;
    [SerializeField] private LayerMask m_targetLayerMask;   // used to determine collisions with objects - allowed to collide with

    private Collider[] m_hitCollider = new Collider[10];
    private Transform m_target;

    private void FixedUpdate()
    {
        m_target = GetNearestTarget(GetEnemiesInRange(m_homingRadius));
        HomeToTarget();
    }


    private Transform GetNearestTarget(Collider[] targets)
    {
        float minDistance = float.MaxValue;
        Transform nearestTarget = null;
        Vector3 currentPosition = transform.position;

        foreach(Collider target in targets)
        {
            if (target != null)
            {
                float distance = Vector3.Distance(target.transform.position, currentPosition);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestTarget = target.transform;
                }
            }
        }
        return nearestTarget;
    }

    private Collider[] GetEnemiesInRange(float m_homingRadius)
    {
        return Physics.OverlapSphere(transform.position, m_homingRadius, m_targetLayerMask);
    }
    private void HomeToTarget()
    {
        // No asteroids to home to
        if (m_target == null)
            return;

        Vector3 direction = (m_target.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
        m_rigidBody.velocity = transform.forward * m_speed;

        // transform.LookAt(m_target); equivalent to ->>>
        /*  Vector3 direction = (m_target.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
         */


    }
}
