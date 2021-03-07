using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{

    public UnityEvent OnExplode;

    [SerializeField]
    private FloatParameter explosionRadius;

    [SerializeField]
    private DamageType damageType;

    public void Explode()
    {
        OnExplode.Invoke();
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius.GetValue(), Vector2.zero);
        foreach (var item in hits)
        {
            if(item.transform.gameObject != this.gameObject)
            {
                IDamageable target = item.transform.GetComponent<IDamageable>();
                if(target != null)
                {
                    target.ApplyDamage(1, damageType);
                }
            }
        }
    }

}