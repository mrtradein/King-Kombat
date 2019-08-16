using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{

    GameController gameController;
    GameObject gameController_Obj;
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
       
        timeLeft = Random.Range(0.0f, 1.0f);
        
        gameController_Obj = GameObject.Find("Game Controller");
        gameController = gameController_Obj.GetComponent<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.attacking_turn == 0)
        {
            AI_Defending();
        }
        else
        {

            AI_Attacking();
        }
  
    }

    private void AI_Defending()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            gameController.AI_Defend();
            //Debug.Log("AI_Defend");
            timeLeft = Random.Range(0.0f, 1.5f);

        }
    }

    private void AI_Attacking()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            gameController.AI_Attack();
            Debug.Log("AI_Attack");
            timeLeft = Random.Range(0.0f, 10.0f);

        }
    }
}
