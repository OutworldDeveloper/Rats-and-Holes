using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : Movement
{

    [SerializeField]
    private FloatParameter minChangeDirectionTime;

    [SerializeField]
    private FloatParameter maxChangeDirectionTime;

    private bool isMovingUp;
    private float nextChangeTime;

    private void Start()
    {
        ChangeDirection();
    }

    private void Update()
    {
        if (isMovingUp)
        {
            if (transform.position.y <= 3)
                transformController.SetVelocity(-Vector3.right + Vector3.up);
            else
            {
                transformController.SetVelocity(-Vector3.right); ;
            }
        }
        else
        {
            if (transform.position.y >= -3)
                transformController.SetVelocity(-Vector3.right - Vector3.up);
            else
            {
                transformController.SetVelocity(-Vector3.right); ;
            }
        }
        if (Time.time >= nextChangeTime)
        {
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        isMovingUp = !isMovingUp;
        nextChangeTime = Time.time + Random.Range(minChangeDirectionTime.GetValue(), maxChangeDirectionTime.GetValue());
    }

}
