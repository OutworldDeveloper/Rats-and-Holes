using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager instance;

    public event EventHandler OnMusicEnded;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Animator animator;

    public void PlayMusic(AudioClip music)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeMusic(music));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator ChangeMusic(AudioClip newMusic)
    {
        /*
        if (audioSource.isPlaying)
        {
            while (audioSource.volume > 0f)
            {
                audioSource.volume -= 0.01f;
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
        */
        animator.SetBool("On", false);
        yield return new WaitForSecondsRealtime(0.25f);
        audioSource.clip = newMusic;
        audioSource.Play();
        /*
        while (audioSource.volume < 0.2f)
        {
            audioSource.volume += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        */
        animator.SetBool("On", true);
        yield return new WaitForSecondsRealtime(0.25f);
        StartCoroutine(EndMusic());
    }

    private IEnumerator EndMusic()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        if (OnMusicEnded != null) OnMusicEnded(this, EventArgs.Empty);
    }

}