using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int score;
    public float speed;

    public event Action<Asteroid> OnAsteroidDestroy;

    private Vector3 dir;

    private void Start()
    {
        do
        {
            dir = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        } while (dir == Vector3.zero);
    }

    protected virtual void Move()
    {
        transform.position += dir.normalized * speed * Time.deltaTime;
    }

    private void Update()
    {
        Move();
    }

    public virtual void BeforeDestroy()
    {
        //add points etc.
        OnAsteroidDestroy?.Invoke(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BeforeDestroy();
        Destroy(gameObject);
    }
}
