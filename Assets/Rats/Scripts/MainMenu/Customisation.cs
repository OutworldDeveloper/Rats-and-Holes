using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Customisation : MonoBehaviour
{

    [SerializeField]
    private ClothesUI prefabClothesUI;

    [SerializeField]
    private Transform parentClothesUI;

    [SerializeField]
    private TMP_Text slotTextUI;

    private bool findBySlot;
    private Slot targetSlot;

    private List<ClothesUI> clothesUIs = new List<ClothesUI>();

    public void SelectSlot(Slot newSlot)
    {
        targetSlot = newSlot;
        slotTextUI.text = newSlot.displayName;
        findBySlot = true;
        RefreshClothesList();
    }

    public void ResetSlot()
    {
        slotTextUI.text = "All items";
        findBySlot = false;
        RefreshClothesList();
    }

    public void ChangeCharacter(Character character)
    {
        PlayerProfile.SelectCharacter(character);
    }

    private void OnEnable()
    {
        Slot.ClothesUpdated += Slot_ClothesUpdated;
        RefreshClothesList();
    }

    private void OnDisable()
    {
        Slot.ClothesUpdated -= Slot_ClothesUpdated;
    }

    private void Slot_ClothesUpdated(object sender, System.EventArgs e)
    {
        RefreshClothesList();
    }

    private void RefreshClothesList()
    {
        foreach (var item in clothesUIs)
        {
            Destroy(item.gameObject);
        }
        clothesUIs.Clear();

        foreach (var item in Clothes.GetUnlockedClothes())
        {
            if(findBySlot)
            {
                if(targetSlot == item.slot)
                {
                    ClothesUI newClothesUI = Instantiate(prefabClothesUI, parentClothesUI, false);
                    newClothesUI.Setup(item);
                    clothesUIs.Add(newClothesUI);
                }
            }
            else
            {
                ClothesUI newClothesUI = Instantiate(prefabClothesUI, parentClothesUI, false);
                newClothesUI.Setup(item);
                clothesUIs.Add(newClothesUI);
            }
        }
    }

}