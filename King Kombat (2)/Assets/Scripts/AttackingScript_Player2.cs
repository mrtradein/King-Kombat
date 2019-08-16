using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackingScript_Player2 : MonoBehaviour
{
    public GameController gameController;
    public GameObject gameController_Obj;

    public GameObject blockSFX;
    public GameObject attackSFX;

    public GameObject block_txt;
    public GameObject HitText;

    public UI_Manager uiM;
    public GameObject uiM_obj;

    // Start is called before the first frame update
    void Start()
    {
        uiM_obj = GameObject.Find("UI Manager");
        uiM = uiM_obj.GetComponent<UI_Manager>();

        
        //block_txt.transform.SetParent(worldSpaceCanvas_Player_1.transform,false);

        gameController_Obj = GameObject.Find("Game Controller");
        gameController = gameController_Obj.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player_1_HeadCollider")
        {
            gameController.Decrease_Player_2_Stamina();

            Debug.Log("Player 1 - head hit");

            Instantiate(attackSFX, this.transform.position, Quaternion.identity);
            gameController.HeadHit_Player1();
            gameController.DecreaseNumberOfHits();
            DoHeadDamage();

        }

        if (other.tag == "Player_1_BodyCollider")
        {
            gameController.Decrease_Player_2_Stamina();

            Debug.Log("Player 1 - body hit");
            Instantiate(attackSFX, this.transform.position, Quaternion.identity);
            gameController.BodyHit_Player1();
            gameController.DecreaseNumberOfHits();
            DoBodyDamage();
        }

        if (other.tag == "Player_1_LegsCollider")
        {
            gameController.Decrease_Player_2_Stamina();

            Debug.Log("Player 1 - legs hit");
            Instantiate(attackSFX, this.transform.position, Quaternion.identity);
            gameController.LegsHit_Player1();
            gameController.DecreaseNumberOfHits();
            DoLegsDamage();
        }

        // If collider hits defending hit box
        if (other.tag == "Player_1_HeadDefending")
        {
            gameController.Decrease_Player_2_Stamina();

            Debug.Log("Player 1 - head block");
            //Instantiate(attackSFX, this.transform.position, Quaternion.identity);
            Instantiate(blockSFX, this.transform.position, Quaternion.identity);
            uiM.BlockOverlay_ON();

            gameController.DecreaseNumberOfHits();
        }

        if (other.tag == "Player_1_BodyDefending")
        {
            gameController.Decrease_Player_2_Stamina();

            Debug.Log("Player 1 - body block");
            //Instantiate(attackSFX, this.transform.position, Quaternion.identity);
            Instantiate(blockSFX, this.transform.position, Quaternion.identity);

            uiM.BlockOverlay_ON();

            gameController.DecreaseNumberOfHits();

        }

        if (other.tag == "Player_1_LegsDefending")
        {
            gameController.Decrease_Player_2_Stamina();

            Debug.Log("Player 1 - legs block");
            //Instantiate(attackSFX, this.transform.position, Quaternion.identity);
            Instantiate(blockSFX, this.transform.position, Quaternion.identity);

            uiM.BlockOverlay_ON();

            gameController.DecreaseNumberOfHits();

        }
    }

    private void DoHeadDamage()
    {
        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 1)
            gameController.player1_Head_Health -= 10.0f;

        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 2)
            gameController.player1_Head_Health -= 20.0f;

        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 3)
            gameController.player1_Head_Health -= 30.0f;
    }

    private void DoBodyDamage()
    {
        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 1)
            gameController.player1_Body_Health -= 10.0f;

        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 2)
            gameController.player1_Body_Health -= 20.0f;

        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 3)
            gameController.player1_Body_Health -= 30.0f;
    }

    private void DoLegsDamage()
    {
        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 1)
            gameController.player1_Legs_Health -= 10.0f;

        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 2)
            gameController.player1_Legs_Health -= 20.0f;

        if (gameController.Player2.GetComponent<Animator>().GetInteger("Attack Power") == 3)
            gameController.player1_Legs_Health -= 30.0f;
    }
}
