using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    public float XP_current;
    public float XP_until_next_level;
    public int level_current;

    // Start is called before the first frame update
    void Start()
    {
        
        //PlayerPrefs.SetInt("level_current", 1);
        //PlayerPrefs.SetFloat("XP_current", 0.0f);


        Check();
        UpdateNextLevel();

        XP_current = PlayerPrefs.GetFloat("XP_current");
        level_current = PlayerPrefs.GetInt("level_current");

        XP_until_next_level = level_current * 200;

        if (XP_current >= XP_until_next_level)
        {
            levelIncre();
        }




    }

    private void Update()
    {
       
    }

    public void Check()
    {
        if(level_current <= 1)
        {
            level_current = 1;
        }


    }

    public void levelIncre()
    {
        int temp = PlayerPrefs.GetInt("level_current");
        temp++;
        PlayerPrefs.SetInt("level_current", temp);
        Debug.Log("Incre");


    }

    public void UpdateNextLevel()
    {
        //level_current = XP_current / 100
    }

}
