using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float m_currentHp = 1f;
    [SerializeField] private float m_maxHp = 10f;
    [SerializeField] private int m_team = 0;

    public float Team => m_team;
    public float HealthPercent => m_currentHp / m_maxHp;

    public void Damage(float amount) 
    {
        if (m_currentHp <= 0)
            return;

        float newHealth = m_currentHp - amount;
        m_currentHp = Mathf.Clamp(newHealth, 0, m_maxHp);

        if (m_currentHp == 0)
            Destroy(gameObject);
    }

    
}
