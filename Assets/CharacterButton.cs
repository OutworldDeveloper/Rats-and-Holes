using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterButton : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI textName;

    private Character targetCharacter;

    public void Select()
    {
        PlayerProfile.SelectCharacter(targetCharacter);
    }

    public void Setup(Character character)
    {
        targetCharacter = character;
        textName.text = character.charactersName;
    }
   
}