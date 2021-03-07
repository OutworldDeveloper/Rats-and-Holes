using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopItem : ScriptableObject
{

    public static List<ShopItem> GetShopItems()
    {
        List<ShopItem> shopItems = new List<ShopItem>();
        foreach (var item in Resources.LoadAll<ShopItem>("Shop/"))
        {
            shopItems.Add(item);
        }
        return shopItems;
    }
    
    public string displayName;

    [TextArea]
    public string description;

    public Sprite image;

    public int cost;

    public bool Buy()
    {
        if(CanBuy())
        {
            if (PlayerProfile.RemoveMoney(cost))
            {
                OnBuy();
                return true;
            }
        }
        return false;
    }

    public abstract bool CanBuy();

    protected abstract void OnBuy();

}