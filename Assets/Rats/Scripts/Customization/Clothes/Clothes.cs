using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clothing", menuName = "Clothes")]
public class Clothes : UnlockableItem
{

    public static Clothes GetClothing(string id)
    {
        foreach (var item in Resources.LoadAll<Clothes>("Clothes/"))
        {
            if (item.name == id)
            {
                return item;
            }
        }
        return null;
    }

    public static List<Clothes> GetClothes()
    {
        List<Clothes> clothes = new List<Clothes>();
        foreach (var item in Resources.LoadAll<Clothes>("Clothes/"))
        {
            clothes.Add(item);
        }
        return clothes;
    }

    public static List<Clothes> GetClothes(Slot slot)
    {
        List<Clothes> clothes = new List<Clothes>();
        foreach (var item in Resources.LoadAll<Clothes>("Clothes/"))
        {
            if(item.slot == slot) clothes.Add(item);
        }
        return clothes;
    }

    public static List<Clothes> GetUnlockedClothes()
    {
        List<Clothes> clothes = new List<Clothes>();
        foreach (var item in Resources.LoadAll<Clothes>("Clothes/"))
        {
            if (item.isUnlocked()) clothes.Add(item);
        }
        return clothes;
    }

    public static List<Clothes> GetUnlockedClothes(Slot targetSlot)
    {
        List<Clothes> clothes = new List<Clothes>();
        foreach (var item in Resources.LoadAll<Clothes>("Clothes/"))
        {
            if (item.isUnlocked() && item.slot == targetSlot)
            {
                clothes.Add(item);
            }
        }
        return clothes;
    }

    public string displayName;

    public CharacterClothes femaleSprites;
    public CharacterClothes maleSprites;

    public bool hideHair;

    public Slot slot;

    public Sprite GetSprite(bool front)
    {
        Sprite sprite = null;
        if (PlayerProfile.GetSelectedCharacter().clothingType == ClothingType.female)
        {
            if (front)
            {
                sprite = femaleSprites.ingameBaseFront.baseSprite;
            }
            else
            {
                sprite = femaleSprites.ingameBaseBack.baseSprite;
            }
        }
        else if (PlayerProfile.GetSelectedCharacter().clothingType == ClothingType.male)
        {
            if (front)
            {
                sprite = maleSprites.ingameBaseFront.baseSprite;
            }
            else
            {
                sprite = maleSprites.ingameBaseBack.baseSprite;
            }
        }
        return sprite;
    }

    public Sprite GetHandSprite(bool front)
    {
        Sprite sprite = null;
        if (PlayerProfile.GetSelectedCharacter().clothingType == ClothingType.female)
        {
            if (front)
            {
                sprite = femaleSprites.ingameHandFront.baseSprite;
            }
            else
            {
                sprite = femaleSprites.ingameHandBack.baseSprite;
            }
        }
        else if (PlayerProfile.GetSelectedCharacter().clothingType == ClothingType.male)
        {
            if (front)
            {
                sprite = maleSprites.ingameHandFront.baseSprite;
            }
            else
            {
                sprite = maleSprites.ingameHandBack.baseSprite;
            }
        }
        return sprite;
    }

    public Sprite GetBackgroundSprite(bool front)
    {
        Sprite sprite = null;
        if (PlayerProfile.GetSelectedCharacter().clothingType == ClothingType.female)
        {
            if (front)
            {
                sprite = femaleSprites.ingameBaseFront.backgroundSprite;
            }
            else
            {
                sprite = femaleSprites.ingameBaseBack.backgroundSprite;
            }
        }
        else if (PlayerProfile.GetSelectedCharacter().clothingType == ClothingType.male)
        {
            if (front)
            {
                sprite = maleSprites.ingameBaseFront.backgroundSprite;
            }
            else
            {
                sprite = maleSprites.ingameBaseBack.backgroundSprite;
            }
        }
        return sprite;
    }

    public bool isEquipped()
    {
        if (this.slot.GetClothes() != null)
        {
            return this.slot.GetClothes().name == this.name;
        }
        return false;
    }

    public bool isAccepted()
    {
        if(isUnlockedByDefault)
        {
            return true;
        }
        else
        {
            return PlayerPrefs.GetInt(this.name + "isAccepted") == 1;
        }
    }

    public void Accept()
    {
        PlayerPrefs.SetInt(this.name + "isAccepted", 1);
    }

}

[System.Serializable]
public struct CharacterClothes
{

    public ClothesSprite menuFront;
    public ClothesSprite menuBack;
    public ClothesSprite ingameBaseFront;
    public ClothesSprite ingameBaseBack;
    public ClothesSprite ingameHandFront;
    public ClothesSprite ingameHandBack;

}

[System.Serializable]
public struct ClothesSprite
{

    public Sprite baseSprite;
    public Sprite backgroundSprite;

}