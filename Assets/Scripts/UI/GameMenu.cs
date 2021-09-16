using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour, IToggable
{
    [SerializeField] FloatValueUpdater[] valueUpdater;

    private void Start()
    {
        UpdateAll();
    }

    public void Toggle(bool visiable)
    {
        this.gameObject.SetActive(visiable);

        UpdateAll();
    }

    private void UpdateAll()
    {
        foreach (FloatValueUpdater updater in valueUpdater)
        {
            updater.UpdateValue();
        }
    }
}
