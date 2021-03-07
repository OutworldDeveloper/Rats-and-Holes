using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMenu : MonoBehaviour
{

    [SerializeField]
    private CharacterButton btnPrefab;

    [SerializeField]
    private Transform parent;

    private List<GameObject> objects = new List<GameObject>();

    public void Refresh()
    {
        foreach (var item in objects)
        {
            Destroy(item);
        }
        objects.Clear();
        foreach (var item in Character.GetCharacters())
        {
            if(item.isUnlocked())
            {
                CharacterButton newBtn = Instantiate(btnPrefab, parent);
                newBtn.Setup(item);
                objects.Add(newBtn.gameObject);
            }
        }
    }

}