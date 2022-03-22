using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{

    [SerializeField] private BoxCollider m_boxCollider;
    Vector3 min;
    Vector3 max;

    // Start is called before the first frame update
    void Start()
    {
        min = m_boxCollider.bounds.min;
        max = m_boxCollider.bounds.max;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ShipMovement>() == null)
        {
            Destroy(other.gameObject);
            return;
        }

        
        Vector3 position = other.transform.position;

        if (position.z > max.z || position.z < min.z)
            position.z *= -1;
        if (position.x > max.x || position.x < min.x)
            position.x *= -1;
        other.transform.position = position;
    }
}
