using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInspector_magicBox : MonoBehaviour, IShopInspector<MagicBox>
{

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private UI_MagicBoxContent prefab;

    private List<GameObject> gameObjects = new List<GameObject>();

    public void Display(MagicBox shopItem)
    {
        Clear();
        foreach (var item in shopItem.clothes)
        {
            UI_MagicBoxContent newContent = Instantiate(prefab, parent);
            newContent.Show(item);
            gameObjects.Add(newContent.gameObject);
        }
    }

    private void Clear()
    {
        foreach (var item in gameObjects)
        {
            Destroy(item);
        }
        gameObjects.Clear();
    }

}

public interface IShopInspector<T> where T: ShopItem
{

    void Display(T shopItem);

}