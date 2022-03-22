using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    [SerializeField] private float m_lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, m_lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
