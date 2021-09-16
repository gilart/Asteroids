using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int score;
    public float speed;

    private Vector3 dir;

    public event Action<Asteroid> OnAsteroidDestroy;

    [SerializeField] FloatValue Score;

    CollisionHandler collisionHandler;

    private void Start()
    {
        collisionHandler = GetComponent<CollisionHandler>();
        collisionHandler.OnObjectDestroy += CollisionHandler_OnObjectDestroy;

        do
        {
            dir = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        } while (dir == Vector3.zero);
    }

    private void CollisionHandler_OnObjectDestroy()
    {
        BeforeDestroy();
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
        Score.Value += score;

        OnAsteroidDestroy?.Invoke(this);
    }
}
