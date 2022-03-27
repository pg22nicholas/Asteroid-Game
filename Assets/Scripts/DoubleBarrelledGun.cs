using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBarrelledGun : Weapon
{
    [SerializeField] private float bulletSeparation = 2f;
    
    protected override void Shoot()
    {
        Vector3 dirLeft = (Quaternion.AngleAxis(-90f, Vector3.up) * transform.forward).normalized;
        Vector3 dirRight = (Quaternion.AngleAxis(90f, Vector3.up) * transform.forward).normalized;
        Instantiate(m_projectilePrefab, transform.position + dirLeft * bulletSeparation, transform.rotation);   
        Instantiate(m_projectilePrefab, transform.position + dirRight * bulletSeparation, transform.rotation); 
    }
}
