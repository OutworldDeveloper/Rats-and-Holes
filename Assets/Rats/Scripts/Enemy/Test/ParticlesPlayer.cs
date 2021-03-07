using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPlayer : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem particleSystem;

    public void Play()
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
    }

}