using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float m_maxSpeed = 30f;
    [SerializeField] private float m_turnSpeed = 30f;
    [SerializeField] private float m_acceleration = 10f;
    [SerializeField] private Rigidbody m_rigidBody;

    private float m_thrustInput;
    private float m_turnInput;

    private void OnValidate()
    {
        if (m_rigidBody == null)
            Debug.LogError("RigidBody is null");
    }
    // Start is called before the first frame update
    void Start()
    {
        // Prevent bullets from colliding with ship and other bullets
        Physics.IgnoreLayerCollision(7, 7);
        if (m_rigidBody == null)
        {
            //throw new System.Exception("");
            Debug.LogError("Log");
            Destroy(gameObject); // Destroys the actual game object
            Destroy(this); // Destroys ship script
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_thrustInput = Input.GetAxis("Vertical");
        m_turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Vector3 force = m_thrustInput * m_acceleration * transform.forward;
        Move(force);

        Vector3 torque = m_turnInput * m_turnSpeed * transform.up;
        Rotate(torque);
    }

    void Move(Vector3 force)
    {
        m_rigidBody.AddForce(force);
        if (m_rigidBody.velocity.magnitude >= m_maxSpeed)
            m_rigidBody.velocity = m_rigidBody.velocity.normalized * m_maxSpeed;

        //Debug.Log("Ship speed is: " + m_rigidBody.velocity);
        //Debug.Log(string.Format("Ship speed is: {0}", m_rigidBody.velocity));
        //Debug.Log("Ship speed is: ${m_rigidBody.velocity}" + m_rigidBody.velocity);
        
    }

    void Rotate(Vector3 torque)
    {
        m_rigidBody.AddTorque(torque);
    }
}
