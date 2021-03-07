using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Player player;

    private void Start()
    {      
        Vector3 newPosition = new Vector3(playerCamera.OrthographicBounds().min.x - 2f, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rat rat = collision.GetComponent<Rat>();
        if (rat != null)
        {
            Destroy(collision.gameObject);
            player.SetDamage(1);
        }
    }

}