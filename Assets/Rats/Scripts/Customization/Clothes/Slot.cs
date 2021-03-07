using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Slot", menuName = "Slot")]
public class Slot : ScriptableObject
{

    public static event EventHandler ClothesUpdated;

    public static Slot GetSlot(string id)
    {
        foreach (var item in Resources.LoadAll<Slot>("Slots/"))
        {
            if (item.name == id)
            {
                return item;
            }
        }
        return null;
    }

    public static List<Slot> GetSlots()
    {
        List<Slot> slots = new List<Slot>();
        foreach (var item in Resources.LoadAll<Slot>("Slots/"))
        {
            slots.Add(item);
        }
        return slots;
    }

    public string displayName;

    public int renderOrder;

    public Sprite icon;

    public Clothes GetClothes()
    {
        return Clothes.GetClothing(PlayerPrefs.GetString(this.name));
    }

    public void SetClothes(Clothes clothes)
    {
        PlayerPrefs.SetString(this.name, clothes.name);
        if (ClothesUpdated != null) ClothesUpdated(this, EventArgs.Empty);
    }

    public void ClearSlot()
    {
        PlayerPrefs.DeleteKey(this.name);
        if (ClothesUpdated != null) ClothesUpdated(this, EventArgs.Empty);
    }
  
}