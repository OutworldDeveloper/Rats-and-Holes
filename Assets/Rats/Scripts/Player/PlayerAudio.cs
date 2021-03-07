using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private Sound damageSound, healSound, deadeyeSound, shootSound;

    [SerializeField]
    private AudioSource damageAudioSource, healAudioSource, deadeyeAudioSource, shootAudioSource;

    private float lastKnownHealth;

    private void Start()
    {
        player.OnHealthChanged += Player_OnHealthChanged;
        player.OnDeadeyeStart += Player_OnDeadeyeStart;
        player.OnPlayerShooted += Player_OnPlayerShooted;
    }

    private void OnDestroy()
    {
        player.OnHealthChanged -= Player_OnHealthChanged;
        player.OnDeadeyeStart -= Player_OnDeadeyeStart;
        player.OnPlayerShooted -= Player_OnPlayerShooted;
    }

    private void Player_OnPlayerShooted(RaycastHit2D hit)
    {
        PlaySound(shootAudioSource, shootSound);
    }

    private void Player_OnDeadeyeStart(bool started)
    {
        if (started)
        {
            PlaySound(deadeyeAudioSource, deadeyeSound);
        }
    }

    private void Player_OnHealthChanged(int health)
    {
        if (lastKnownHealth < health)
        {
            PlaySound(healAudioSource, healSound);
        }
        else if (lastKnownHealth > health)
        {
            PlaySound(damageAudioSource, damageSound);
        }
    }

    private void PlaySound(AudioSource audioSource, Sound sound)
    {
        audioSource.clip = sound.audio;
        audioSource.volume = sound.volume;
        audioSource.pitch = Random.Range(sound.minPitch, sound.maxPitch);
        audioSource.Play();
    }

}