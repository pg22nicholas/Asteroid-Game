using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidOnCollision : MonoBehaviour
{
    [SerializeField] private float m_damage = 1f;
    [SerializeField] private int m_team = 0;
    [SerializeField] private float m_minimumVelocity = 5f;

    private void OnTriggerEnter(Collider other) 
    {
        TryDamage(other);
    }

    private void OnCollisionEnter(Collision collision) 
    {
        // If asteroid hit by projectile
        // If (tryProjectileHit(collision.collider)) 
           // return;

        if (collision.relativeVelocity.magnitude >= m_minimumVelocity)
        TryDamage(collision.collider);
    }

    private void TryDamage(Collider other) 
    {
        if (other.TryGetComponent<Health>(out var temporary) && temporary.Team != m_team)
        {
            temporary.Damage(m_damage);
        }
    }

    private bool tryProjectileHit(Collider other) {
        if (other.TryGetComponent<Bullet>(out var temporary)) 
        {
            Destroy(gameObject);
            temporary.OnHitAsteroid();
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
