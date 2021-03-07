using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private Text ui_hightScore;

    [SerializeField]
    private ItemsShowcase itemsShowcase;

    [SerializeField]
    private StatisticVariable bestScoreStat;

    public void StartGame()
    {
        PlayerProfile.playCustoms = false;
        SceneLoader.instance.LoadScene(2);
    }
    public void StartCustoms()
    {
        PlayerProfile.playCustoms = true;
        SceneLoader.instance.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneLoader.instance.LoadScene(1);
    }

    public void ShowItems()
    {
        StartCoroutine(ShowcaseNewItems());
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        itemsShowcase.gameObject.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(ShowcaseNewItems());

        if (bestScoreStat.GetStatistic() > 0)
        {
            ui_hightScore.text = "Your high score is " + bestScoreStat.GetStatistic();
        }
        else
        {
            ui_hightScore.gameObject.SetActive(false);
        }


        if (!PlayerPrefs.HasKey("Played"))
        {
            foreach (var item in Clothes.GetUnlockedClothes())
            {
                item.slot.SetClothes(item);
            }
            PlayerPrefs.SetInt("Played", 1);
        }

    }

    private IEnumerator ShowcaseNewItems()
    {
        foreach (var item in Clothes.GetClothes())
        {
            if(item.isUnlocked() && !item.isAccepted())
            {
                itemsShowcase.Show(item);
                yield return new WaitUntil(() => itemsShowcase.isAccepted == true);
                item.Accept();
                itemsShowcase.Hide();
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

}