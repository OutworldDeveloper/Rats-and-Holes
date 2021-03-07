using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject hearthPrefab;

    [SerializeField]
    private Sprite fullHeart;

    [SerializeField]
    private Sprite emptyHeart;

    [SerializeField]
    private bool showBrokenHearts;

    private void Start()
    {
        player.OnHealthChanged += Player_OnHealthChanged;
        UpdateHealthBar();
    }

    private void OnDestroy()
    {
        player.OnHealthChanged -= Player_OnHealthChanged;
    }

    private void Player_OnHealthChanged(int health)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        int x = 0;
        for (int i = 0; i < player.maxHealth; i++)
        {
            if(x < player.health)
            {
                GameObject heart = Instantiate(hearthPrefab, this.transform, false);
                heart.GetComponent<Image>().sprite = fullHeart;
            }
            else
            {
                if (showBrokenHearts)
                {
                    GameObject heart = Instantiate(hearthPrefab, this.transform, false);
                    heart.GetComponent<Image>().sprite = emptyHeart;
                }
            }
            x++;
        }
    }

}