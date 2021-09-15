using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] Transform shootingSpot;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] AudioClip shoot;
    [SerializeField] AudioSource source;

    public void Shoot()
    {
        source.PlayOneShot(shoot);

        GameObject bullet = Instantiate(bulletPrefab, shootingSpot.position, shootingSpot.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();        
        rb.AddForce(this.transform.up * 550f);
    }
}
