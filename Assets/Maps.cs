using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps : MonoBehaviour
{

    [SerializeField]
    private MapBtn btnPrefab;

    [SerializeField]
    private Transform parent;

    private List<GameObject> gameObjects = new List<GameObject>();

    public void Refresh()
    {
        foreach (var item in gameObjects)
        {
            Destroy(item);
        }
        gameObjects.Clear();
        foreach (var item in Map.GetMaps())
        {
            if(item.isUnlocked())
            {
                MapBtn newBtn = Instantiate(btnPrefab, parent);
                newBtn.Setup(item, this);
                gameObjects.Add(newBtn.gameObject);
            }
        }
    }

    public void SelectMap(Map map)
    {
        PlayerProfile.SelectMap(map);
        Refresh();
    }

}