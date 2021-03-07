using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MagicBox", menuName = "Shop/MagicBox")]
public class MagicBox : ShopItem
{

    [SerializeField]
    public List<Clothes> clothes = new List<Clothes>();

    protected override void OnBuy()
    {
        List<Clothes> targetClothes = new List<Clothes>();
        foreach (var item in clothes)
        {
            if (item.isUnlocked() == false) targetClothes.Add(item);
        }
        targetClothes[Random.Range(0, targetClothes.Count)].Unlock();
    }

    public override bool CanBuy()
    {
        bool canBuy = false;
        foreach (var item in clothes)
        {
            if (item.isUnlocked() == false) canBuy = true;
        }
        return canBuy;
    }

}