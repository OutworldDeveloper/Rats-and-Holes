using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map", menuName = "Map")]
public class Map : UnlockableItem
{

    public static Map GetDefaultMap()
    {
        foreach (var item in GetMaps())
        {
            if (item.isDefault) return item;
        }
        return null;
    }

    public static Map GetMap(string name)
    {
        Map map = default;
        foreach (var item in GetMaps())
        {
            if (item.name == name) map = item;
        }
        return map;
    }


    public static List<Map> GetMaps()
    {
        List<Map> maps = new List<Map>();
        foreach (var item in Resources.LoadAll<Map>("Maps/"))
        {
            maps.Add(item);
        }
        return maps;
    }

    public List<Sprite> holesSprites;
    public GameObject mapPrefab;

    public Sprite preview;

    public bool isDefault;

}