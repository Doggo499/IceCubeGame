using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] iceSliding;
    public AudioClip[] factoryDestroying;
    private AudioSource source;

    [Range(0.1f, 0.5f)]
    public float volumeChangeMultiplier = 0.2f;

    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplier = 0.2f;

    [Range(0.1f, 1f)]
    public float maxVolume = 0.5f;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void WalkSound()
    {
        source.clip = iceSliding[Random.Range(0, iceSliding.Length)];
        source.volume = Random.Range(maxVolume - volumeChangeMultiplier, maxVolume);
        source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
        source.PlayOneShot(source.clip);
    }

    public void DestroySound()
    {
        source.clip = factoryDestroying[Random.Range(1, factoryDestroying.Length)];
        source.volume = Random.Range(maxVolume - volumeChangeMultiplier, maxVolume);
        source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
        source.PlayOneShot(source.clip);
    }
}