using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public static SceneLoader instance;

    [SerializeField]
    private Animator animator;

    private bool isLoading;

    public void LoadScene(int sceneIndex)
    {
        if (isLoading)
            return;
        else
            StartCoroutine(SceneTransition(sceneIndex));
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        animator.enabled = false;
    }

    private IEnumerator SceneTransition(int sceneIndex)
    {
        isLoading = true;
        animator.enabled = true;
        animator.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1.5f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        yield return new WaitUntil(() => operation.isDone);
        yield return new WaitForSecondsRealtime(0.5f);
        animator.SetTrigger("End");
        isLoading = false;
        Time.timeScale = 1f;
    }

}