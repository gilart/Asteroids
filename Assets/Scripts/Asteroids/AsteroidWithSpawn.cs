using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidWithSpawn : Asteroid
{
    public GameObject ObjectToSpawn;

    public override void BeforeDestroy()
    {
        GameManager.Instance.SpawnAsteroids(ObjectToSpawn, transform.position);
        
        base.BeforeDestroy();
    }
}
