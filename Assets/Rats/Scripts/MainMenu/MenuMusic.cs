using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{

    [SerializeField]
    private AudioClip menuMusic;

    private void Start()
    {
        MusicManager.instance.PlayMusic(menuMusic);
        MusicManager.instance.OnMusicEnded += Instance_OnMusicEnded;
    }

    private void OnDestroy()
    {
        MusicManager.instance.OnMusicEnded -= Instance_OnMusicEnded;
    }

    private void Instance_OnMusicEnded(object sender, System.EventArgs e)
    {
        MusicManager.instance.PlayMusic(menuMusic);
    }

}