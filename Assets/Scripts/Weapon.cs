using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float m_cooldown = 0.25f;
    [SerializeField] private KeyCode m_input = KeyCode.Mouse0;
    [SerializeField] protected Projectile m_projectilePrefab;

    protected float m_lastShotTime = 0f;

    // Update is called once per frame
    void Update()
    {
        m_lastShotTime += Time.deltaTime;
        if (Input.GetKey(m_input) && m_lastShotTime > m_cooldown)
        {
            Shoot();
            m_lastShotTime = 0f;
        }
    }
    protected virtual void Shoot()
    {
        Instantiate(m_projectilePrefab, transform.position, transform.rotation);
    } 
        
}
