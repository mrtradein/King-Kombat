using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendingScript_Player1 : MonoBehaviour
{
    GameController gameController;
    public GameObject gameController_Obj;

    public GameObject Player_1_Head;
    public GameObject Player_1_Body;
    public GameObject Player_1_Legs;

    // Start is called before the first frame update
    void Start()
    {
        gameController_Obj = GameObject.Find("Game Controller");
        gameController = gameController_Obj.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if playing defending animation, set collider as trigger
        if (this.GetComponent<Animator>().GetInteger("Defending") == 0)
        {
            //Debug.Log("Defending 0");
            Player_1_Head.tag = "Player_1_HeadCollider";
            Player_1_Body.tag = "Player_1_BodyCollider";
            Player_1_Legs.tag = "Player_1_LegsCollider";

            

        }
        if (this.GetComponent<Animator>().GetInteger("Defending") == 1)
        {
            Debug.Log("Defending 1");
            Player_1_Head.tag = "Player_1_HeadDefending";
        }
        if (this.GetComponent<Animator>().GetInteger("Defending") == 2)
        {
            Debug.Log("Defending 2");
            Player_1_Body.tag = "Player_1_BodyDefending";

        }
        if (this.GetComponent<Animator>().GetInteger("Defending") == 3)
        {
            Debug.Log("Defending 3");
            Player_1_Legs.tag = "Player_1_LegsDefending";

        }
    }

    
}
