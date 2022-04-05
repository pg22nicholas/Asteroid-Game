using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject m_uiRoot;

    private void Awake()
    {
        ToggleScreen(false);
    }

    public void ToggleScreen(bool isActive)
    {
        m_uiRoot.SetActive(isActive);
    }

    void Update()
    {
        
    }
}
