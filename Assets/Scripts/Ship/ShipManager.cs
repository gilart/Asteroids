using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager
{
    CollisionHandler shipCollision;

    public GameObject shipInstance;

    [SerializeField]private int lives = 3;

    public void Setup()
    {
        shipCollision = shipInstance.GetComponent<CollisionHandler>();
        shipCollision.OnShipDestroy += ShipCollision_OnShipDestroy;

        IsAlive = true;
    }

    private void ShipCollision_OnShipDestroy()
    {
        IsAlive = false;
    }

    public void ResetShip()
    {
        shipInstance.transform.position = new Vector3(0, 0, 0);
        shipInstance.transform.rotation = Quaternion.identity;

        shipInstance.SetActive(false);
        shipInstance.SetActive(true);
    }

    public bool IsAlive { get; set; }
    public bool HasLives { get { return lives != 0; } }    
}
