using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlueFireplace : Drop
{

    [SerializeField]
    private FloatParameter burnTime;

    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private SlownessAura slownessAura;

    private float endTime;
    private bool activated;

    public UnityEvent OnFireStarted;

    public override void Take(Player player)
    {
        if (activated) return;
        endTime = Time.time + burnTime.GetValue();
        slownessAura.isWorking = true;
        particles.gameObject.SetActive(true);
        OnFireStarted.Invoke();
        activated = true;
    }

    private void Awake()
    {
        slownessAura.isWorking = false;
        particles.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (activated == false) return;
        if(Time.time >= endTime)
        {
            Destroy(this.gameObject);
        }
    }

}
