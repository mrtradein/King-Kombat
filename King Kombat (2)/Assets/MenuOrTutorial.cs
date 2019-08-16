using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOrTutorial : MonoBehaviour
{

    public int TutorialCompleted;


    // Start is called before the first frame update
    void Start()
    {
        TutorialCompleted = PlayerPrefs.GetInt("TutorialCompleted");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MenuOrTutorialChecck()
    {
        if (TutorialCompleted == 0)
        {
            PlayerPrefs.SetInt("TutorialCompleted", 1);

            SceneManager.LoadScene("How To Play Scene");
        }
        else
        {
            SceneManager.LoadScene("Menu Scene");
        }
    }
}
