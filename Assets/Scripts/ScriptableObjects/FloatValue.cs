using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("FloatValue"))]
public class FloatValue : ScriptableObject
{
    [SerializeField]private float value;
    public event Action OnValueChanged;

    public float Value
    {
        get
        {
            return value;
        }
        set
        {
            if(this.value != value)
            {                
                this.value = value;
                OnValueChanged?.Invoke();
            }
        }
    }
}
