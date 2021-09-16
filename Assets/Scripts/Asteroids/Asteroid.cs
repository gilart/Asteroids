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

    AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] ParticleSystem Explosion;

    private void Start()
    {
        source = GetComponent<AudioSource>();

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
        AudioSource.PlayClipAtPoint(clip, transform.position);

        Explosion.Play();
        Explosion.transform.parent = null;

        GameManager.Instance.UpdateHUDScore(score);
        OnAsteroidDestroy?.Invoke(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BeforeDestroy();
        Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        BeforeDestroy();
        Destroy(gameObject);
    }
}
