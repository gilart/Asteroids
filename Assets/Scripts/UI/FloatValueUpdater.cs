using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatValueUpdater : MonoBehaviour, IValueUpdater
{
    [SerializeField] FloatValue floatValueObject;
    [SerializeField] Text text;

    public virtual void UpdateValue()
    {
        text.text = floatValueObject.Value.ToString();
    }
}
