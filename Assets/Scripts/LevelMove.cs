using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;
    public ASyncLoader loader;

    public string levelName;



    private void OnTriggerEnter2D(Collider2D other)
        {
            print("Trigger Entered");

            if (other.CompareTag("Player"))
            {
            loader.LoadLevelBtn(levelName);

            //print("Switching Scene to " + sceneBuildIndex);
            //    SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }
        }




}