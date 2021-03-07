using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MagicBoxContent : MonoBehaviour
{

    [SerializeField]
    private GameObject checkBox;

    [SerializeField]
    private UIClothingPreview clothingPreview;

    public void Show(Clothes clothing)
    {
        clothingPreview.Show(clothing);
        checkBox.SetActive(clothing.isUnlocked());
    }

}