using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : UnlockableItem
{

    public static Character GetCharacter(string id)
    {
        foreach (var item in GetCharacters())
        {
            if (item.name == id) return item;
        }
        return null;
    }

    public static Character GetDefaultCharacter()
    {
        foreach (var item in GetCharacters())
        {
            if (item.isDefault) return item;
        }
        return null;
    }

    public static List<Character> GetCharacters()
    {
        List<Character> characters = new List<Character>();
        foreach (var item in Resources.LoadAll<Character>("Characters/"))
        {
            characters.Add(item);
        }
        return characters;
    }

    public string charactersName;
    public Sprite bodySpriteFront, bodySpriteBack;
    public Sprite hairSpriteFront, hairSpriteBack;
    public Sprite handSpriteFront, handSpriteBack;
    public float handOffsetX;
    public float handOffsetY;
    public Vector2 gunPosition;

    public ClothingType clothingType;

    public bool isDefault;

}

public enum ClothingType
{
    female,
    male,
    none
}