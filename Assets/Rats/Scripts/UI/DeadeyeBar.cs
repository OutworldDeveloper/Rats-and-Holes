using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadeyeBar : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private Image deadeyeImage;

    [SerializeField]
    private Image deadeyeTreashold;

    private void Start()
    {
        player.OnDeadeyeChanged += Player_OnDeadeyeChanged;
        deadeyeTreashold.fillAmount = player.deadeyeTreashold / 100;
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
        deadeyeImage.fillAmount = deadeye / 100;
    }

}