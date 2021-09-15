using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotationThrust = 100;

    //SFX
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip engine;
    [SerializeField] ParticleSystem thurst;

    Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();        
    }

    public void Move()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!source.isPlaying)
        {
            source.Play();            
        }

        if(!thurst.isPlaying)
        {
            thurst.Play();
        }        
    }

    public void Rotate(float rotateThisFrame)
    {
        transform.Rotate(Vector3.forward * rotateThisFrame * rotationThrust * Time.deltaTime);
    }

    private void LateUpdate()
    {
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }
    }

    public void StopMoving()
    {
        source.Stop();
        thurst.Stop();
    }
}
