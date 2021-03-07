using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesUI : MonoBehaviour
{

    [SerializeField]
    private Image heartImage;

    [SerializeField]
    private UIClothingPreview preview;

    private Clothes clothes;

    public void Setup(Clothes newClothes)
    {
        heartImage.gameObject.SetActive(newClothes.isEquipped());
        preview.Show(newClothes);
        clothes = newClothes;
    }

    public void Btn_Equip()
    {
        if(clothes.isEquipped())
        {
            clothes.slot.ClearSlot();
        }
        else
        {
            clothes.slot.SetClothes(clothes);
        }
    }

}