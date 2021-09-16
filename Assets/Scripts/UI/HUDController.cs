using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour, IToggable
{
    [SerializeField] GameObject fixedJoystick;
    [SerializeField] GameObject actionButton;

    [SerializeField] Text score;
    [SerializeField] Text lives;
    [SerializeField] Text level;

    [SerializeField] FloatValue highscore;
    [SerializeField] FloatValue objectScore;
    [SerializeField] FloatValue objectLives;
    [SerializeField] FloatValue objectLevel;

    private void Start()
    {
        objectScore.OnValueChanged += UpdateHUDScore;
        objectLevel.OnValueChanged += UpdateHUDLevel;
        objectLives.OnValueChanged += UpdateHUDLives;
    }

    public void Toggle(bool visiable)
    {
        this.gameObject.SetActive(visiable);
    }

    public void HideTouchesComponents()
    {
        fixedJoystick.SetActive(false);
        actionButton.SetActive(false);
    }

    public void UpdateHUDLives()
    {
        this.lives.text = objectLives.Value.ToString();
    }

    public void UpdateHUDLevel()
    {
        this.level.text = objectLevel.Value.ToString();
    }

    public void UpdateHUDScore()
    {
        this.score.text = objectScore.Value.ToString();

        if (objectScore.Value > highscore.Value)
        {
            highscore.Value = objectScore.Value;
        }
    }
}
