using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] Transform shootingSpot;

    public void Shoot()
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = this.shootingSpot.position;
        bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(this.transform.up * 350f);
    }
}
