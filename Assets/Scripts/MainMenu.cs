using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene(11);
    }

    public void BackTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void Mutants0()
    {
        SceneManager.LoadScene(6);
    }

    public void Mutants1()
    {
        SceneManager.LoadScene(7);
    }

    public void Mutants2()
    {
        SceneManager.LoadScene(8);
    }

    public void Mutants3()
    {
        SceneManager.LoadScene(9);
    }

    public void Mutants4()
    {
        SceneManager.LoadScene(10);
    }
}

