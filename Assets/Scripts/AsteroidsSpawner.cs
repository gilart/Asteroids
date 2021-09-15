using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] GameObject bigAsteroidPrefab;

    List<Asteroid> asteroids = new List<Asteroid>();

    public Vector2 screenBounds;
    Camera MainCamera;

    Vector3 shipPosition = new Vector3(0, 0);

    private void Start()
    {
        MainCamera = Camera.main;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));        
    }

    public void SpawnSpecificAsteroidsAtPosition(GameObject objectToSpawn, Vector3 position)
    {
        int asteroidsAmount = HowManyAsteroindsToSpawn();
        SpawnAsteroids(asteroidsAmount, objectToSpawn, position);
    }

    public void SpawnAsteroidsBasedOnLevel(int level)
    {
        int asteroidsAmount = HowManyAsteroindsToSpawn();
        SpawnAsteroids(asteroidsAmount + level, bigAsteroidPrefab);
    }

    private void SpawnAsteroids(int asteroidsAmount, GameObject objectToSpawn, Vector3 pos)
    {
        for (int i = 0; i < asteroidsAmount; i++)
        {
            AsteroidSpawn(objectToSpawn, pos);
        }
    }

    private void SpawnAsteroids(int asteroidsAmount, GameObject objectToSpawn)
    {
        for (int i = 0; i < asteroidsAmount; i++)
        {
            Vector3 pos = FindPositionToSpawn();
            AsteroidSpawn(objectToSpawn, pos);
        }
    }

    private Vector3 FindPositionToSpawn()
    {
        Vector3 pos = Vector3.zero;

        do
        {
            pos = new Vector3(Random.Range(screenBounds.x, -screenBounds.x), Random.Range(screenBounds.y, -screenBounds.y));
        } while (DistBetweenPoints(pos) < 5);

        return pos;
    }

    private float DistBetweenPoints(Vector3 pos)
    {
        return Mathf.Sqrt(Mathf.Pow(pos.x - shipPosition.x, 2) + Mathf.Pow(pos.y - shipPosition.y, 2));
    }

    private void AsteroidSpawn(GameObject objectToSpawn, Vector3 pos)
    {
        GameObject asteroidGO = Instantiate(objectToSpawn, pos, Quaternion.identity);

        Asteroid asteroid = asteroidGO.GetComponent<Asteroid>();

        asteroid.OnAsteroidDestroy += Asteroid_OnAsteroidDestroy;

        asteroids.Add(asteroid);
    }

    private int HowManyAsteroindsToSpawn()
    {
        return Random.Range(1, 3);
    }

    public void RemoveAsteroids()
    {
        foreach (var item in asteroids)
        {
            Destroy(item.gameObject);
        }

        asteroids.Clear();
    }

    private void Asteroid_OnAsteroidDestroy(Asteroid asteroid)
    {
        asteroids.Remove(asteroid);
    }

    public bool AreThereAnyAsteroids()
    {
        return asteroids.Count != 0;
    }


}
