using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        //System check
        if(SystemInfo.deviceType == DeviceType.Handheld)
        {
            isDevice = true;
        }
        else
        {
            isDevice = false;
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

    //private int level = 0;
    private bool isDevice = false;

    [SerializeField] private AsteroidsSpawner asteroidsSpawner;
    [SerializeField] private ShipManager shipManager;

    //Scriptable Objects
    [SerializeField] private FloatValue highscore;
    [SerializeField] private FloatValue score;
    [SerializeField] private FloatValue level;

    //UI
    [SerializeField] private HUDController HUD;
    [SerializeField] private GameMenu GameOverMenu;

    //Music
    [SerializeField] MusicController music;

    private void ResetUI()
    {
        level.Value = 0;
        score.Value = 0;
        shipManager.ResetShipLives();
    }

    public void SpawnAsteroids(GameObject objectToSpawn, Vector3 position)
    {
        asteroidsSpawner.SpawnSpecificAsteroidsAtPosition(objectToSpawn, position);
    }

    private void SpawnShip()
    {
        shipManager.SpawnShip(isDevice);
    }

    public void StartGame()
    {
        if(!isDevice)
        {
            HUD.HideTouchesComponents();
        }
        
        music.PlayGameMusic();
        ResetUI();
        StartCoroutine(GameLoop());
    }    

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        if(shipManager.HasLives)
        {
            StartCoroutine(GameLoop());
        }
        else
        {
            HUD.Toggle(false);
            GameOverMenu.Toggle(true);
            music.PlayMenuMusic();
        }
        
    }

    private IEnumerator RoundStarting()
    {      
        HUD.Toggle(true);        

        if(!shipManager.IsAlive)
        {
            SpawnShip();
        }
        else
        {
            level.Value++;
        }

        asteroidsSpawner.SpawnAsteroidsBasedOnLevel(level.Value);

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
        return shipManager.IsAlive && asteroidsSpawner.AreThereAnyAsteroids();
    }

    private IEnumerator RoundEnding()
    {
        asteroidsSpawner.RemoveAsteroids();
        yield return new WaitForSeconds(2f);        
    }
}
