using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyClothes : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer bodySprite, armSprite;

    [SerializeField]
    private SpriteRenderer hairSprite;

    [SerializeField]
    private Transform handParent;

    [SerializeField]
    private Transform gunTransform;

    private bool isFacingRight;

    private List<SpriteRenderer> clothesSprites = new List<SpriteRenderer>();

    public void ShowFront(bool b)
    {
        if(b != isFacingRight)
        {         
            isFacingRight = b;
            Refresh();
        }
    }

    public Transform GetHandTransform()
    {
        return handParent;
    }

    private void OnEnable()
    {
        Slot.ClothesUpdated += Slot_ClothesUpdated;
        PlayerProfile.OnCharacterChanged += PlayerProfile_OnCharacterChanged;
        Refresh();
    }

    private void OnDisable()
    {
        Slot.ClothesUpdated -= Slot_ClothesUpdated;
        PlayerProfile.OnCharacterChanged -= PlayerProfile_OnCharacterChanged;
    }

    private void PlayerProfile_OnCharacterChanged(Character character)
    {
        Refresh();
    }

    private void Slot_ClothesUpdated(object sender, System.EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        ClearClothes();

        SetupCharacter();

        bool hideHair = false;
        foreach (var item in Slot.GetSlots())
        {
            Clothes targetClothes = item.GetClothes();
            if (targetClothes != null)
            {
;               SpriteRenderer newBodySprite = CreateClothes(targetClothes.GetSprite(!isFacingRight), bodySprite.sortingOrder + item.renderOrder);
                newBodySprite.transform.SetParent(bodySprite.transform, false);
                clothesSprites.Add(newBodySprite);
                if (targetClothes.GetHandSprite(!isFacingRight) != null)
                {
                    SpriteRenderer newArmSprite = CreateClothes(targetClothes.GetHandSprite(!isFacingRight), armSprite.sortingOrder + item.renderOrder);
                    newArmSprite.transform.SetParent(armSprite.transform, false);
                    clothesSprites.Add(newArmSprite);
                }              
                if(targetClothes.GetBackgroundSprite(!isFacingRight) != null)
                {
                    SpriteRenderer newBackgroundSprite = CreateClothes(targetClothes.GetBackgroundSprite(!isFacingRight), bodySprite.sortingOrder - item.renderOrder);
                    newBackgroundSprite.transform.SetParent(bodySprite.transform, false);
                    clothesSprites.Add(newBackgroundSprite);
                }

                if (targetClothes.hideHair)
                {
                    hideHair = true;
                }

            }
        }
        hairSprite.gameObject.SetActive(!hideHair);
    }

    private void SetupCharacter()
    {

        armSprite.flipX = isFacingRight;
        bodySprite.flipX = isFacingRight;

        Character targetCharacter = PlayerProfile.GetSelectedCharacter();

        gunTransform.localPosition = targetCharacter.gunPosition;

        handParent.localPosition = new Vector2(targetCharacter.handOffsetX, targetCharacter.handOffsetY);
        armSprite.transform.localPosition = new Vector2(-targetCharacter.handOffsetX, -targetCharacter.handOffsetY);

        if (isFacingRight)
        {
            bodySprite.sprite = targetCharacter.bodySpriteBack;
            armSprite.sprite = targetCharacter.handSpriteBack;
            hairSprite.sprite = targetCharacter.hairSpriteBack;
        }
        else
        {
            bodySprite.sprite = targetCharacter.bodySpriteFront;
            armSprite.sprite = targetCharacter.handSpriteFront;
            hairSprite.sprite = targetCharacter.hairSpriteFront;    
        }
    }

    private SpriteRenderer CreateClothes(Sprite sprite, int renderOrder)
    {
        GameObject go = new GameObject();
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.flipX = isFacingRight;
        sr.sprite = sprite;
        sr.sortingOrder = renderOrder;
        return sr;
    }
    

    private void ClearClothes()
    {
        foreach (var item in clothesSprites)
        {
            Destroy(item.gameObject);
        }
        clothesSprites.Clear();
    }

}