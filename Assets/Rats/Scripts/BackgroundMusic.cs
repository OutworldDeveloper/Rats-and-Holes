using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    [SerializeField]
    private Game game;

    [SerializeField]
    private AudioClip[] musics;

    [SerializeField]
    private AudioClip endMusic;

    [SerializeField]
    private AudioClip endMusicGood;

    private bool stop;

    private void Start()
    {
        GameManager.instance.OnGameEnded += Instance_OnGameEnded;
        MusicManager.instance.OnMusicEnded += Instance_OnMusicEnded;
        PlayRandomMusic();
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameEnded -= Instance_OnGameEnded;
        MusicManager.instance.OnMusicEnded -= Instance_OnMusicEnded;
    }

    private void Instance_OnMusicEnded(object sender, System.EventArgs e)
    {
        PlayRandomMusic();
    }

    private void Instance_OnGameEnded(GameResults gameResults)
    {
        MusicManager.instance.OnMusicEnded -= Instance_OnMusicEnded;
        stop = true;
        MusicManager.instance.PlayMusic(endMusic);
    }

    private void PlayRandomMusic()
    {
        if (stop) return;
        MusicManager.instance.PlayMusic(musics[Random.Range(0, musics.Length)]);
    }

}