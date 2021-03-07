using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "Sound")]
public class Sound : ScriptableObject
{

    public AudioClip audio;

    public float volume;

    public float minPitch;
    public float maxPitch;

}