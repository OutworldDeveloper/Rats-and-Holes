using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformController))]
public abstract class Movement : MonoBehaviour
{

    protected TransformController transformController;

    public virtual void Stop()
    {
        transformController.SetVelocity(Vector3.zero);
    }

    protected virtual void Awake()
    {
        transformController = GetComponent<TransformController>();
    }

    protected virtual void OnDisable()
    {
        Stop();
    }

}