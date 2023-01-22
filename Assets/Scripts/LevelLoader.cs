using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    float waitForSeconds = 3f;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(AutoLoadStartScene());
        }
    }

    public IEnumerator AutoLoadStartScene()
    {
        yield return new WaitForSeconds(waitForSeconds);
        LoadNextScene();
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadLevel1Scene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }
    public void Exit()
    {
        Application.Quit();
    }
}