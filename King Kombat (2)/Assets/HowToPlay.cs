using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HowToPlay : MonoBehaviour
{
    public GameObject cover1;
    public GameObject cover2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cover1()
    {
        cover1.SetActive(true);
        cover2.SetActive(false);
    }
    public void Cover2()
    {
        cover2.SetActive(true);
        cover1.SetActive(false);
    }
}
