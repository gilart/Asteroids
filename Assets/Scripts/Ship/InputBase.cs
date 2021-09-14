using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
[RequireComponent(typeof(ShipShooting))]
public abstract class InputBase : MonoBehaviour
{
    [SerializeField] protected ShipMovement shipMovement;
    [SerializeField] protected ShipShooting shipShooting;

    protected abstract void ProcessThurst();
    protected abstract void ProcessRotation();

    protected abstract void ProcessShooting();

    protected void Move()
    {
        shipMovement.Move();
    }

    protected void Rotate(float rotationThisFrame)
    {
        shipMovement.Rotate(rotationThisFrame);
    }

    protected void Shoot()
    {
        shipShooting.Shoot();
    }

    private void Update()
    {
        ProcessRotation();
        ProcessThurst();
        ProcessShooting();
    }
}
