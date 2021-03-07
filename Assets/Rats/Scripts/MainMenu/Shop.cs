using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class Shop : MonoBehaviour
{

    public UnityEvent OnItemPurchased;
    public UnityEvent OnItemPurchaseFailed;

    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private ShopItemUI shopItemPrefab;

    [SerializeField]
    private Transform shopParent;

    [SerializeField]
    private TextMeshProUGUI textItemName, textCost, textDescription;

    [SerializeField]
    private GameObject buyButton;

    [SerializeField]
    private ShopInspector_magicBox magicboxInspector;

    private ShopItem selectedItem;

    public void BuySelectedItem()
    {
        if (selectedItem == null) return;
        if(selectedItem.Buy() == true)
        {
            OnItemPurchased.Invoke();
            SelectItem(selectedItem);
        }
        else
        {
            OnItemPurchaseFailed.Invoke();
        }
    }

    public void SelectItem(ShopItem shopItem)
    {
        selectedItem = shopItem;
        textItemName.text = selectedItem.displayName;
        textCost.text = "Cost: " + selectedItem.cost + " points";
        textDescription.text = selectedItem.description;

        buyButton.SetActive(shopItem.CanBuy());

        magicboxInspector.gameObject.SetActive(shopItem is MagicBox);

        if (shopItem is MagicBox)
        {
            magicboxInspector.Display(shopItem as MagicBox);
        }

    }

    private void Start()
    {
        UpdateMoneyText();
        PlayerProfile.OnMoneyChanged += PlayerProfile_OnMoneyChanged;
        SetupShopItems();

        SelectItem(ShopItem.GetShopItems()[0]);

    }

    private void OnDestroy()
    {
        PlayerProfile.OnMoneyChanged -= PlayerProfile_OnMoneyChanged;
    }

    private void SetupShopItems()
    {
        foreach (var item in ShopItem.GetShopItems())
        {
            Instantiate(shopItemPrefab, shopParent).Setup(item, this);
        }
    }

    private void PlayerProfile_OnMoneyChanged(float money)
    {
        UpdateMoneyText();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = PlayerProfile.GetCurrentMoney() + " points";
    }

}