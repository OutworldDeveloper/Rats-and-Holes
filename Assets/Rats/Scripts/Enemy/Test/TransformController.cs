using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BoolEvent : UnityEvent<bool> { }

[System.Serializable]
public class FloatEvent : UnityEvent<float> { }

public class TransformController : MonoBehaviour
{

    public BoolEvent OnDirectionChanged;
    public FloatEvent OnSpeedChanged;

    private float moveSpeed;
    private Vector3 velocityVector;
    private bool isFacingRight;
    private bool stop;

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
        OnSpeedChanged.Invoke(speed);
    }

    public void Stop(bool stop)
    {
        this.stop = stop;
        if (stop) OnSpeedChanged.Invoke(0);
        else OnSpeedChanged.Invoke(moveSpeed);
    }

    private void Update()
    {
        if (stop) return;
        //Move
        transform.position += velocityVector * moveSpeed * Time.deltaTime;
        //Direction
        if (velocityVector == Vector3.zero)
        {
            return;
        }
        else
        {
            if (isFacingRight)
            {
                if (transform.position.x + velocityVector.x < transform.position.x)
                {
                    isFacingRight = false;
                    OnDirectionChanged.Invoke(false);
                }
            }
            else
            {
                if (transform.position.x + velocityVector.x > transform.position.x)
                {
                    isFacingRight = true;
                    OnDirectionChanged.Invoke(true);
                }
            }
        }
    }

}
