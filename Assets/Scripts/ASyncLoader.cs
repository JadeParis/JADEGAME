using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class ASyncLoader : MonoBehaviour
{
    [Header("menu Screens")]
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private GameObject MainMenu;

  

    private void Awake()
    {
        Time.timeScale = 1;
    }

    public void LoadLevelBtn(string LevelToLoad)
    {
        MainMenu.SetActive(false);
        LoadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(LevelToLoad));
    }
    IEnumerator LoadLevelASync(string LevelToLoad)
    {
        AsyncOperation LoadOperation = SceneManager.LoadSceneAsync(LevelToLoad);
        
        while (!LoadOperation.isDone)
        {
            float progressiveValue = Mathf.Clamp01(LoadOperation.progress / 0.9f); 
            //LoadingSlider.value = progressiveValue;
            yield return null;
        }

    }
}
