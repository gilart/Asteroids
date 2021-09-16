using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidWithSpawn : Asteroid
{
    public GameObject ObjectToSpawn;

    public override void BeforeDestroy()
    {
        //event kiedy stworze nowy meteoryt i idzie do spawnera z instancjami
        GameManager.Instance.SpawnAsteroids(ObjectToSpawn, transform.position);
        
        base.BeforeDestroy();
    }
}
