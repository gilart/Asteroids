using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public event Action OnObjectDestroy;
    [SerializeField] AudioClip explosion;
    [SerializeField] ParticleSystem explosionParticle;

    private void BeforeDestroy()
    {
        OnObjectDestroy?.Invoke();

        AudioSource.PlayClipAtPoint(explosion, transform.position);
        explosionParticle.Play();
        explosionParticle.transform.parent = null;

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BeforeDestroy();        
    }

    private void OnParticleCollision(GameObject other)
    {
        BeforeDestroy();
    }
}
