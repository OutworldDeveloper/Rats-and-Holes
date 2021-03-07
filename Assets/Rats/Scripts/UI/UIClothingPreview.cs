using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIClothingPreview : MonoBehaviour
{

    [SerializeField]
    private Image image, imageBack;

    public void Show(Clothes clothing)
    {
        image.sprite = clothing.maleSprites.menuFront.baseSprite;
        Sprite sprite = clothing.maleSprites.menuFront.backgroundSprite;
        if (sprite != null)
            imageBack.sprite = clothing.maleSprites.menuFront.backgroundSprite;
        else
            imageBack.gameObject.SetActive(false);
    }

}