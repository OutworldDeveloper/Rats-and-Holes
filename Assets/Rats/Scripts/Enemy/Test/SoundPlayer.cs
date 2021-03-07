using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{

    [SerializeField]
    private Sound sound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioSource.pitch = Random.Range(sound.minPitch, sound.maxPitch);
        audioSource.volume = sound.volume;
        audioSource.PlayOneShot(sound.audio);
    }

}