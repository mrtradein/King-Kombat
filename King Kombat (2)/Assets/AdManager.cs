using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAd()
    {
        if(Advertisement.IsReady())
        Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Player Reward");
                break;
            case ShowResult.Skipped:
                Debug.Log("No reward");
                break;
            case ShowResult.Failed:
                Debug.Log("No Reward");
                break;



        }
    }
}
