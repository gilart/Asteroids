using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    [SerializeField] FloatValue highscore;
    [SerializeField] Text highscoreText;

    private void Start()
    {
        UpdateHighscore();
        highscore.OnValueChanged += Highscore_OnValueChanged;
    }

    private void Highscore_OnValueChanged()
    {
        UpdateHighscore();
    }

    public void UpdateHighscore()
    {
        highscoreText.text = highscore.Value.ToString();
    }
}
