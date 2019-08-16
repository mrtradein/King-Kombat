using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }

    public void OpenFightScene()
    {
        SceneManager.LoadScene("Fight Scene");
    }

    public void OpenARScene()
    {
        SceneManager.LoadScene("ARScene");
    }

    public void OpenHowToPlayer()
    {
        SceneManager.LoadScene("How To Play" +
            " Scene");
    }

    public void OpenEditFighter()
    {
        SceneManager.LoadScene("Edit Fighter Scene");
    }


}
