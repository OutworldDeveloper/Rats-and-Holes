using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapBtn : MonoBehaviour
{

    [SerializeField]
    private GameObject check;

    [SerializeField]
    private Image image;

    private Map targetMap;

    private Maps maps;

    public void Setup(Map map, Maps maps)
    {
        targetMap = map;
        this.maps = maps;
        image.sprite = map.preview;
        check.SetActive(PlayerProfile.GetSelectedMap() == map);
    }

    public void Select()
    {
        maps.SelectMap(targetMap);
    }

}