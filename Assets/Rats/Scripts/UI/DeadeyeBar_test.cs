using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadeyeBar_test : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private Color deadeyeFullColor;

    [SerializeField]
    private Color deadeyeEmptyColor;

    [SerializeField]
    private Image[] images;

    private void Start()
    {
        player.OnDeadeyeChanged += Player_OnDeadeyeChanged;
        //Reset
        UpdateDeadeyeBar(player.deadeye);
    }

    private void OnDestroy()
    {
        player.OnDeadeyeChanged -= Player_OnDeadeyeChanged;
    }

    private void Player_OnDeadeyeChanged(float deadeye)
    {
        UpdateDeadeyeBar(deadeye);
    }

    private void UpdateDeadeyeBar(float deadeye)
    {
        float f = (deadeye - player.deadeyeTreashold) / (images.Length - (player.deadeyeTreashold / images.Length));
        float x = 0;
        foreach (var item in images)
        {
            if (x <= f)
            {
                item.color = deadeyeFullColor;
            }
            else
            {
                item.color = deadeyeEmptyColor;
            }
            x++;
        }
    }

}