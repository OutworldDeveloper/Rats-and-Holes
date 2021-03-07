using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{

    [SerializeField]
    private Drop dropPrefab;

    public void CreateDrop()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
    }

}