using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textName, textDesc, textCost;

    [SerializeField]
    private Image imagePreview;

    private ShopItem shopItem;
    private Shop shop;

    public void Setup(ShopItem shopItem, Shop shop)
    {
        this.shopItem = shopItem;
        this.shop = shop;
        imagePreview.sprite = shopItem.image;
        textName.text = shopItem.displayName;
        textDesc.text = shopItem.description;
        textCost.text = shopItem.cost.ToString();
    }

    public void btn_Buy()
    {
        //shop.BuyItem(shopItem);
        shop.SelectItem(shopItem);
    }

}