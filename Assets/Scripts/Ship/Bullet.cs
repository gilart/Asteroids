using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float maxLifeTime = 2f;

    private void Start()
    {
        Destroy(this.gameObject, maxLifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        Destroy(this.gameObject);        
    }
}
