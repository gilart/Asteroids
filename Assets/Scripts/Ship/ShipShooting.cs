using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioSource source;

    [SerializeField] ParticleSystem bullets;

    public void Shoot()
    {
        source.PlayOneShot(shoot);
        bullets.Play();
    }
}
