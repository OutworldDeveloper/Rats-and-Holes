using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{

    public void LoadMainMenu()
    {

    }

    private void Start()
    {
        SceneManager.LoadScene(1);
    }

}