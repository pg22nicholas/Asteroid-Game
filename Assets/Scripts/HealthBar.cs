using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health m_health;
    [SerializeField] private Image m_healthBarFill;

    // Update is called once per frame
    void Update()
    {
        m_healthBarFill.fillAmount = m_health != null ? m_health.HealthPercent : 0f;
    }
}
