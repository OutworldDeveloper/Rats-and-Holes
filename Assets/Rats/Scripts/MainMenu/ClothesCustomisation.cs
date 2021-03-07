using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesCustomisation : MonoBehaviour
{

    [SerializeField]
    private ClothesUI prefabClothesUI;

    [SerializeField]
    private Transform parentClothesUI;

    private List<ClothesUI> clothesUIs = new List<ClothesUI>();

    public void Btn_ChangeCharacter(Character character)
    {
        PlayerProfile.SelectCharacter(character);
    }

    private void Start()
    {
        Slot.ClothesUpdated += Slot_ClothesUpdated;
        Refresh();
    }

    private void OnDestroy()
    {
        Slot.ClothesUpdated -= Slot_ClothesUpdated;
    }

    private void Slot_ClothesUpdated(object sender, System.EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        foreach (var item in clothesUIs)
        {
            Destroy(item.gameObject);
        }
        clothesUIs.Clear();
        
        foreach (var item in Clothes.GetUnlockedClothes())
        {
            ClothesUI newClothesUI = Instantiate(prefabClothesUI, parentClothesUI, false);
            newClothesUI.Setup(item);
            clothesUIs.Add(newClothesUI);
        }
        
        //StartCoroutine(GenerateButtons());
    }

    private IEnumerator GenerateButtons()
    {
        foreach (var item in Clothes.GetUnlockedClothes())
        {
            ClothesUI newClothesUI = Instantiate(prefabClothesUI, parentClothesUI, false);
            newClothesUI.Setup(item);
            clothesUIs.Add(newClothesUI);
            yield return new WaitForSeconds(0.01f);
        }
    }

}