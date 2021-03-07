using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField]
    private Player player;

    private void Update()
    {
        if (player.health > 0)
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                MobileInput();
            }
            else
            {
                DefaultInput();
            }
        }
    }

    private void MobileInput()
    {
        //Shoot
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            player.Shoot();
        }
    }

    private void DefaultInput()
    {
        //Deadeye
        if (Input.GetMouseButtonDown(1))
        {
            player.EnableDeadeye(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            player.EnableDeadeye(false);
        }

        //Shoot
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            player.Shoot();
        }
    }

}