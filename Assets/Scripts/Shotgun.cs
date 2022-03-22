using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField] private int m_shotCount = 5;
    
    [Range(0, 180)]
    [SerializeField] private float m_spreadAngle = 25f;

    protected override void Shoot()
    {
        for (int i = 0; i < m_shotCount; i++)
        {
            float angle = (i * m_spreadAngle / (m_shotCount - 1)) - (m_spreadAngle * 0.5f);
            Quaternion forward = Quaternion.Euler(0, angle, 0) * transform.rotation;
            Instantiate(m_projectilePrefab, transform.position, forward);
        }
        
    }

}
