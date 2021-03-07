using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessController : MonoBehaviour
{

    [SerializeField]
    private Volume volume;

    [SerializeField]
    private VolumeProfile defaultDeadeyeEffects;

    [SerializeField]
    private VolumeProfile simpleDeadeyeEffects;

    [SerializeField]
    private Animator animator;

    private bool isEnabled;

    public void Enable(bool b)
    {
        isEnabled = b;
        animator.SetBool("IsEnabled", b);
    }

    private void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            volume.profile = simpleDeadeyeEffects;
        }
        else
        {
            volume.profile = defaultDeadeyeEffects;
        }
    }

    private void Update()
    {
        return;
        if(isEnabled)
        {
            if (volume.weight < 1)
                volume.weight = volume.weight + 0.1f;
            else
                volume.weight = 1;
        }
        else
        {
            if (volume.weight > 0)
                volume.weight = volume.weight - 0.1f;
            else
                volume.weight = 0;
        }
    }
}
