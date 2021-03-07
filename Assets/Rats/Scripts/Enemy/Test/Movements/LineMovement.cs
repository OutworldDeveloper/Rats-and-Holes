using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : Movement
{

    public bool isMovingBack;

    private void Update()
    {
        if (isMovingBack)
        {
            transformController.SetVelocity(Vector3.right);
        }
        else
        {
            transformController.SetVelocity(-Vector3.right);
        }
    }

}