using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerField : MonoBehaviour
{

    [SerializeField]
    private LineConnection lineConnectionPrefab;

    [SerializeField]
    private CircleCollider2D triggerCollision;

    private List<Connection> connections = new List<Connection>();

    private List<Rat> enemiesInField = new List<Rat>();

    public void SetRadius(float newRadius)
    {
        triggerCollision.radius = newRadius - 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rat target = collision.transform.GetComponent<Rat>();
        if (target != null)
        {
            enemiesInField.Add(target);
            Connection newConnection = new Connection();
            newConnection.lineConnection = Instantiate(lineConnectionPrefab, transform.position, Quaternion.identity);
            newConnection.lineConnection.SetTarget(target.transform);
            newConnection.targetRat = target;
            connections.Add(newConnection);
        }
    }

    private void Update()
    {
        foreach (var item in connections)
        {
            item.targetRat.isInvencible = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rat target = collision.transform.GetComponent<Rat>();
        if (target != null)
        {
            enemiesInField.Remove(target);
            foreach (var item in connections)
            {
                if(item.targetRat == target)
                {
                    Destroy(item.lineConnection.gameObject);
                    connections.Remove(item);
                    break;
                }
            }
            target.isInvencible = false;
        }
    }

    private void OnDestroy()
    {
        foreach (var item in enemiesInField)
        {
            item.isInvencible = false;
        }
        foreach (var item in connections)
        {
            //Какой то костыль
            if (item.lineConnection != null)
                Destroy(item.lineConnection.gameObject);
        }
    }

    private struct Connection
    {

        public Rat targetRat;
        public LineConnection lineConnection;

    }

}