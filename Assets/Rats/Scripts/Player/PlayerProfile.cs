using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProfile 
{

    public delegate void CharacterChanged(Character character);
    public delegate void MoneyChanged(float money);

    public static event CharacterChanged OnCharacterChanged;
    public static event MoneyChanged OnMoneyChanged;

    public static bool playCustoms;

    public static void SelectMap(Map map)
    {
        PlayerPrefs.SetString("Map", map.name);
    }

    public static Map GetSelectedMap()
    {
        if (PlayerPrefs.HasKey("Map"))
        {
            return Map.GetMap(PlayerPrefs.GetString("Map"));
        }
        return Map.GetDefaultMap();
    }

    public static Character GetSelectedCharacter()
    {
        if (PlayerPrefs.HasKey("Character"))
        {
            return Character.GetCharacter(PlayerPrefs.GetString("Character"));
        }
        return Character.GetDefaultCharacter();

    }

    public static void SelectCharacter(Character character)
    {
        PlayerPrefs.SetString("Character", character.name);
        if (OnCharacterChanged != null) OnCharacterChanged(character);
    }

    public static int GetCurrentMoney()
    {
        return PlayerPrefs.GetInt("Money");
    }

    public static void AddMoney(int amount)
    {
        PlayerPrefs.SetInt("Money", GetCurrentMoney() + amount);
        if (OnMoneyChanged != null) OnMoneyChanged(GetCurrentMoney());
    }

    public static bool RemoveMoney(int amount)
    {
        if(GetCurrentMoney() - amount >= 0)
        {
            PlayerPrefs.SetInt("Money", GetCurrentMoney() - amount);
            if (OnMoneyChanged != null) OnMoneyChanged(GetCurrentMoney());
            return true;
        }
        return false;
    }

}