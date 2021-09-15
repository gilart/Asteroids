using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] Transform shootingSpot;
    [SerializeField] GameObject bulletPrefab;

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingSpot.position, shootingSpot.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();        
        rb.AddForce(this.transform.up * 550f);
    }
}
