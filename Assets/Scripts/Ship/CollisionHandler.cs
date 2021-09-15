using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action OnShipDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        OnShipDestroy?.Invoke();

        Destroy(gameObject);
    }
}
