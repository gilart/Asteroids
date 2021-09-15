using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotationThrust = 100;

    Rigidbody rb;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void Move()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }

    public void Rotate(float rotateThisFrame)
    {
        transform.Rotate(Vector3.forward * rotateThisFrame * rotationThrust * Time.deltaTime);
    }
}
