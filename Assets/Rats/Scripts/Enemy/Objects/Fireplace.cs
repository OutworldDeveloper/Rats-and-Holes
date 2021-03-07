using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : Drop       
{

    [SerializeField]
    private DamageTrigger damageTrigger;

    [SerializeField]
    private ParticleSystem fireParticleSystem;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip startFireAudioClip;

    [SerializeField]
    private FloatParameter lifetime;

    private bool isFire;

    public override void Take(Player player)
    {
        if (isFire)
        {
            return;
        }
        else
        {
            StartCoroutine(FireplaceLife());
            isFire = true;
            audioSource.PlayOneShot(startFireAudioClip);
        }      
    }

    private void Start()
    {
        EnableFireplace(false);
    }

    private void EnableFireplace(bool b)
    {
        damageTrigger.isWorking = b;
        if (b)
        {
            fireParticleSystem.Play();
        }
        else
        {
            fireParticleSystem.Stop();
        }
    }

    private IEnumerator FireplaceLife()
    {
        EnableFireplace(true);
        yield return new WaitForSeconds(lifetime.GetValue());
        EnableFireplace(false);
        Destroy(this.gameObject);
    }

}