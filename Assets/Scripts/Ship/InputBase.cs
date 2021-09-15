using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
[RequireComponent(typeof(ShipShooting))]
public abstract class InputBase : MonoBehaviour
{
    protected ShipMovement shipMovement;
    protected ShipShooting shipShooting;

    private void Start()
    {
        shipMovement = this.GetComponent<ShipMovement>();
        shipShooting = this.GetComponent<ShipShooting>();
    }

    protected abstract void ProcessThurst();
    protected abstract void ProcessRotation();
    protected abstract void ProcessShooting();

    protected void Move()
    {
        if(shipMovement != null)
        {
            shipMovement.Move();
        }        
    }

    protected void StopMoving()
    {
        shipMovement.StopMoving();
    }

    protected void Rotate(float rotationThisFrame)
    {
        if (shipMovement != null)
        {
            shipMovement.Rotate(rotationThisFrame);
        }        
    }

    protected void Shoot()
    {
        if(shipShooting != null)
        {
            shipShooting.Shoot();
        }        
    }

    private void Update()
    {
        ProcessRotation();
        ProcessThurst();
        ProcessShooting();
    }
}
