using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    CollisionHandler shipCollision;

    private GameObject shipInstance;

    [SerializeField] private GameObject shipPrefab;

    [SerializeField] private int lives = 3;

    //SFX
    [SerializeField] private AudioClip respawn;
    AudioSource source;

    public void Setup()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(respawn);

        shipCollision = shipInstance.GetComponent<CollisionHandler>();
        shipCollision.OnShipDestroy += ShipCollision_OnShipDestroy;
        shipCollision.Setup(source);

        IsAlive = true;
    }

    private void ShipCollision_OnShipDestroy()
    {
        IsAlive = false;
        lives--;
        GameManager.Instance.UpdateHUDLives(lives);
    }

    public void ResetShip()
    {        
        this.lives = 3;
        GameManager.Instance.UpdateHUDLives(lives);
    }

    public void SpawnShip()
    {
        shipInstance = Instantiate(shipPrefab, Vector3.zero, Quaternion.identity);        
        Setup();
    }

    public bool IsAlive { get; set; }
    public bool HasLives { get { return lives != 0; } }    
}
