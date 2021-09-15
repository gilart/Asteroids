using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action OnShipDestroy;
    [SerializeField] AudioClip explosion;
    [SerializeField] ParticleSystem explosionParticle;
    AudioSource source;

    public void Setup(AudioSource source)
    {
        this.source = source;
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnShipDestroy?.Invoke();

        source.PlayOneShot(explosion);
        explosionParticle.Play();
        explosionParticle.transform.parent = null;

        Destroy(gameObject);
    }
}
