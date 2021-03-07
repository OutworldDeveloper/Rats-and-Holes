using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject mobileHud;

    [SerializeField]
    private GameObject mobileCheatsHud;

    [SerializeField]
    private GameObject customsHud;

    [SerializeField]
    private Text score;

    [SerializeField]
    private BoolParameter cheats;

    public void Btn_EnableDeadeye()
    {
        player.EnableDeadeye(!player.isDeadeye);
    }

    public void Btn_Bucket()
    {
        player.CatchRat();
    }

    public void Btn_CheatDeadeye()
    {
        player.AddDeadeye(100);
    }

    public void Btn_CheatInvincibility()
    {
        player.godmode = !player.godmode;
    }

    private void Start()
    {
        mobileHud.gameObject.SetActive(UnityEngine.SystemInfo.deviceType == DeviceType.Handheld);
        customsHud.gameObject.SetActive(PlayerProfile.playCustoms);
        if(UnityEngine.SystemInfo.deviceType == DeviceType.Handheld)
        {
            mobileCheatsHud.SetActive(cheats.GetValue());
        }
    }

    private void Update()
    {
        score.text = "Score: " + (int)GameManager.instance.GetCurrentTime();
    }

}