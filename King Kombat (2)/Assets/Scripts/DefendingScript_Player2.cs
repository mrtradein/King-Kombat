using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendingScript_Player2 : MonoBehaviour
{
    GameController gameController;
    public GameObject gameController_Obj;

    public GameObject Player_2_Head;
    public GameObject Player_2_Body;
    public GameObject Player_2_Legs;
   

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
            Player_2_Head.tag = "Player_2_HeadCollider";
            Player_2_Body.tag = "Player_2_BodyCollider";
            Player_2_Legs.tag = "Player_2_LegsCollider";

            //Player_2_Body.SetActive(true);
            //Player_2_Legs.SetActive(true);
            //Player_2_Head.SetActive(true);
            //Player_2_Body.SetActive(true);
            //Player_2_Legs.SetActive(true);

        }
        if (this.GetComponent<Animator>().GetInteger("Defending") == 1)
        {
            //Debug.Log("Defending 1");
            Player_2_Head.tag = "Player_2_HeadDefending";
        }
        if (this.GetComponent<Animator>().GetInteger("Defending") == 2)
        {
            //Debug.Log("Defending 2");
            Player_2_Body.tag = "Player_2_BodyDefending";

        }
        if (this.GetComponent<Animator>().GetInteger("Defending") == 3)
        {
            //Debug.Log("Defending 3");
            Player_2_Legs.tag = "Player_2_LegsDefending";

        }
    }
}
