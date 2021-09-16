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

    private int level = 0;
    private bool isDevice = false;

    [SerializeField] private AsteroidsSpawner asteroidsSpawner;
    [SerializeField] private ShipManager shipManager;
    [SerializeField] private FloatValue highscore;

    //UI
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject GameOverMenu;
    //HUD
    [SerializeField] private Text HUDscore;
    [SerializeField] private Text HUDlives;
    [SerializeField] private Text HUDlevel;
    //Music
    [SerializeField] MusicController music;

    public int Score { get; set; }
    public int Highscore { get; set; }

    public void UpdateHUDLives(int lives)
    {
        this.HUDlives.text = lives.ToString();
    }

    public void UpdateHUDLevel(int level)
    {
        this.HUDlevel.text = level.ToString();
    }

    public void UpdateHUDScore(int score)
    {
        this.Score += score;
        this.HUDscore.text = Score.ToString();

        if(Score > Highscore)
        {
            highscore.Value = Score;
        }
    }

    private void ResetUI()
    {
        level = 0;
        UpdateHUDLevel(level);
        Score = 0;
        UpdateHUDScore(Score);
        shipManager.ResetShip();
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
            HUD.SetActive(false);
            GameOverMenu.SetActive(true);
            music.PlayMenuMusic();
        }
        
    }

    private IEnumerator RoundStarting()
    {      
        HUD.SetActive(true);        

        if(!shipManager.IsAlive)
        {
            SpawnShip();
        }
        else
        {
            level++;
            UpdateHUDLevel(level);
        }

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
        return shipManager.IsAlive && asteroidsSpawner.AreThereAnyAsteroids();
    }

    private IEnumerator RoundEnding()
    {
        asteroidsSpawner.RemoveAsteroids();
        yield return new WaitForSeconds(2f);        
    }
}
