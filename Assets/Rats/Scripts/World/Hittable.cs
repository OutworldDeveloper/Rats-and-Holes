using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem hitEffectPrefab;

    public ParticleSystem GetHitEffect()
    {
        return hitEffectPrefab;
    }

}