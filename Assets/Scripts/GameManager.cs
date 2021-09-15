using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        { 
            return instance;
        }
    }    

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    #endregion

    private int level = 0;

    [SerializeField]private AsteroidsSpawner asteroidsSpawner;

    public void SpawnAsteroids(GameObject objectToSpawn, Vector3 position)
    {
        asteroidsSpawner.SpawnSpecificAsteroidsAtPosition(objectToSpawn, position);
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());
    }

    private IEnumerator RoundStarting()
    {
        asteroidsSpawner.SpawnAsteroidsBasedOnLevel(level);

        yield return null;
    }

    private IEnumerator RoundPlaying()
    {
        while (IsEndGame())
        {
            yield return null;
        }
    }

    private bool IsEndGame()
    {
        //return shipManager.IsAlive && asteroidsSpawner.AreThereAnyAsteroids();
        return false;
    }

    private IEnumerator RoundEnding()
    {
        yield return new WaitForSeconds(2f);
    }
}
