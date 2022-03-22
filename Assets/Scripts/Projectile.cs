using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float m_speed = 10f;
    [SerializeField] private float m_spinForce = 0f;
    [SerializeField] protected Rigidbody m_rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody.velocity = m_speed * transform.forward;
        m_rigidBody.AddTorque(Random.insideUnitSphere * m_spinForce);
    }
}
