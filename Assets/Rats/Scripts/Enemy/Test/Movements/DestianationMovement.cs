using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestianationMovement : Movement
{

    public event EventHandler OnDestinationReached;

    private Vector3 targetPosition;
    private bool shouldMove;

    public void SetDestination(Vector3 position)
    {
        targetPosition = position;
        shouldMove = true;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transformController.SetVelocity(moveDirection);
        }
        else
        {
            shouldMove = false;
            Stop();
            transform.position = targetPosition;
            if (OnDestinationReached != null) OnDestinationReached(this, EventArgs.Empty);
        }
    }

}