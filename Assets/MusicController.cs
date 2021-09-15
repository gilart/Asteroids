using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip Menu;
    [SerializeField] AudioClip Game;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGameMusic()
    {
        audioSource.clip = Game;
        audioSource.Play();
    }

    public void PlayMenuMusic()
    {
        audioSource.clip = Menu;
        audioSource.Play();
    }
}
