using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject cameraRotate;

    // This determines who is attacking
    // 0 = player 1
    // 1 = player 2
    public int attacking_turn = 0;
    public int winner = -1;

    public int attacksRemaining = 3;
    public float timeRemaining = 30;

    public GameObject Player1;
    public float player1_Head_Health = 100.0f;
    public float player1_Body_Health = 100.0f;
    public float player1_Legs_Health = 100.0f;

    public GameObject Player2;
    public float player2_Head_Health = 100.0f;
    public float player2_Body_Health = 100.0f;
    public float player2_Legs_Health = 100.0f;

    public float player_1_Stamina = 100.0f;
    public float player_2_Stamina = 100.0f;

    public float lightAttack_StaminCost = 10;
    public float mediumAttack_StaminCost = 25;
    public float HeavyAttack_StaminCost = 40;

    public UI_Manager uiManager;
    public GameObject uiManager_Obj;

    //public int player1_AttackPower;
    //public float player2_AttackPower;

    // Use this for initialization
    void Start() {
        Set_Player1_AttackPower(1);

        uiManager_Obj = GameObject.Find("UI Manager");
        uiManager = uiManager_Obj.GetComponent<UI_Manager>();

        // default to 1
        Set_Player1_AttackPower(1);
        Set_Player1_AttackPower(1);

        //player1_AttackPower = 0;
        //player2_AttackPower = 0;
      
        ResetTimer();
        attacking_turn = 0;

        Player1 = GameObject.Find("Player 1");
        Player2 = GameObject.Find("Player 2");

        // set number of hits
        ResetNumberOfHits();
    }

    // Update is called once per frame
    void Update() {
        Player1 = GameObject.Find("Player 1");
        Player2 = GameObject.Find("Player 2");
        KeyboardTesting();
        Timer();
        CheckHealth();
    }

    public void InvokeIdle()
    {
        Invoke("Idle", 1.0f);
        //Debug.Log("InvokeIdle");
    }
    public void Idle()
    {
        Player1.GetComponent<Animator>().SetInteger("Attacking", 0);
        Player1.GetComponent<Animator>().SetInteger("Defending", 0);
        Player1.GetComponent<Animator>().SetInteger("Hit", 0);

        Player2.GetComponent<Animator>().SetInteger("Attacking", 0);
        Player2.GetComponent<Animator>().SetInteger("Defending", 0);
        Player2.GetComponent<Animator>().SetInteger("Hit", 0);

        Debug.Log("Idle");

    }

    public void Faint()
    {
        //Player1.GetComponent<Animator>().SetInteger("Attacking", 1);
        //Invoke("Idle", 0.2f);

    }


    public void DefendHead()
    {
        //Player2.GetComponent<Animator>().SetInteger("Attacking", 1);
    }

    public void DefendBody()
    {
        //Player2.GetComponent<Animator>().SetInteger("Attacking", 2);
    }
    public void DefendLegs()
    {
        //Player2.GetComponent<Animator>().SetInteger("Attacking", 3);
    }

    public void HeadHit_Player1()
    {
        Player1.GetComponent<Animator>().SetInteger("Hit", 1);
        InvokeIdle();
    }

    public void HeadHit_Player2()
    {
        Player2.GetComponent<Animator>().SetInteger("Hit", 1);
        InvokeIdle();
    }

    public void BodyHit_Player1()
    {
        Player1.GetComponent<Animator>().SetInteger("Hit", 2);
        InvokeIdle();

    }

    public void BodyHit_Player2()
    {
        Player2.GetComponent<Animator>().SetInteger("Hit", 2);
        InvokeIdle();

    }

    public void LegsHit_Player1()
    {
        Player1.GetComponent<Animator>().SetInteger("Hit", 3);
        InvokeIdle();

    }

    public void LegsHit_Player2()
    {
        Player2.GetComponent<Animator>().SetInteger("Hit", 3);
        InvokeIdle();

    }

    private void OnCollisionEnter(Collision other)
    {

        Debug.Log("entered");

    }

    public void KeyboardTesting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player_2_SwipeUp();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player_2_SwipeLeftRight();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Player_2_SwipeDown();
        }
    }

    public void ResetTimer()
    {
        timeRemaining = 30.0f;
    }

    public void Timer()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining <= 0.0f)
        {
            SkipTurn();
            ResetTimer();
        }
    }

    public int SwitchTurnCheck(int turn)
    {
        if (attacksRemaining == 0)
        {
            CameraRotate();
            turn = 1 - turn;
            ResetNumberOfHits();
            ResetTimer();

            if(attacking_turn == 1)
            {
                Player_2_RegainStamina();
            }
            if (attacking_turn == 0)
            {
                Player_1_RegainStamina();
            }


        }
        return turn;
    }

    public void ResetNumberOfHits()
    {
        attacksRemaining = 3;
    }

    public void DecreaseNumberOfHits()
    {
        if (attacksRemaining >= 0)
        {
            attacksRemaining -= 1;
            attacking_turn = SwitchTurnCheck(attacking_turn);
        }
    }

    public void CameraRotate()
    {
        if (attacking_turn == 0)
        {
            cameraRotate.GetComponent<Animator>().SetInteger("CameraDirection", 1);
            uiManager.defending_UI_Overlay.SetActive(true);

        }
        if (attacking_turn == 1)
        {
            cameraRotate.GetComponent<Animator>().SetInteger("CameraDirection", 2);
            uiManager.defending_UI_Overlay.SetActive(false);

        }
    }

    public void CheckHealth()
    {
        if (player1_Head_Health <= 0.0f || player1_Body_Health <= 0.0f || player1_Legs_Health <= 0.0f)
        {
            Player1.GetComponent<Animator>().SetBool("Dead", true);
            Invoke("WinnerCameraAnimation", 2.0f);
            winner = 1;
            
        }
        if (player2_Head_Health <= 0.0f || player2_Body_Health <= 0.0f || player2_Legs_Health <= 0.0f)
        {
            Player2.GetComponent<Animator>().SetBool("Dead", true);
            Invoke("WinnerCameraAnimation", 2.0f);
            winner = 0;
        }

    }

    public void WinnerCameraAnimation()
    {
        cameraRotate.GetComponent<Animator>().SetInteger("Winner", 1);
        uiManager.WinLoseContainer_On();
    }

    public void Set_Player1_AttackPower(int attackPower)
    {
        Player1.GetComponent<Animator>().SetInteger("Attack Power", attackPower);
        //Debug.Log(attackPower);
    }

    public void Set_Player2_AttackPower(int attackPower)
    {
        Player2.GetComponent<Animator>().SetInteger("Attack Power", attackPower);
    }

    public void Player_1_SwipeUp()
    {
        if (attacking_turn == 0)
        {
            // attacking animation
            bool r = false;
            r = AttackCheck_Player_1();

            if (r == true)
                Player1.GetComponent<Animator>().SetInteger("Attacking", 1);

            if (r == false)
                NotEnoughStamina();

        }
        else
        {
            // defending animation
            Player1.GetComponent<Animator>().SetInteger("Defending", 1);

        }
        // reset back to idle animaiton
        InvokeIdle();
    }

    public void Player_1_SwipeLeftRight()
    {
        if (attacking_turn == 0)
        {
            // attacking animation
            bool r = false;
            r = AttackCheck_Player_1();

            if (r == true)
                Player1.GetComponent<Animator>().SetInteger("Attacking", 2);

            if (r == false)
                NotEnoughStamina();

        }
        else
        {
            // defending animation
            Player1.GetComponent<Animator>().SetInteger("Defending", 2);

        }
        // reset back to idle animaiton
        InvokeIdle();
    }

    public void Player_1_SwipeDown()
    {
        if (attacking_turn == 0)
        {
            // attacking animation
            bool r = false;
            r = AttackCheck_Player_1();

            if (r == true)
                Player1.GetComponent<Animator>().SetInteger("Attacking", 3);

            if (r == false)
                NotEnoughStamina();
        }
        else
        {
            // defending animation
            Player1.GetComponent<Animator>().SetInteger("Defending", 3);

        }

        // reset back to idle animaiton
        InvokeIdle();

    }

    public void Player_2_SwipeUp()
    {
        if (attacking_turn == 1)
        {
            // attacking animation
            //bool r = false;
            //r = AttackCheck_Player_2();

            //if (r == true)
                Player2.GetComponent<Animator>().SetInteger("Attacking", 1);

            //if (r == false)
                //NotEnoughStamina();
        }
        else
        {
            // defending animation
            Player2.GetComponent<Animator>().SetInteger("Defending", 1);

        }
        // reset back to idle animaiton
        InvokeIdle();
    }

    public void Player_2_SwipeLeftRight()
    {
        if (attacking_turn == 1)
        {
            // attacking animation
            //bool r = false;
            //r = AttackCheck_Player_2();

            //if (r == true)
                Player2.GetComponent<Animator>().SetInteger("Attacking", 1);

            //if (r == false)
                //NotEnoughStamina();

        }
        if (attacking_turn == 1)
        {
            // attacking animation
            Player2.GetComponent<Animator>().SetInteger("Attacking", 2);

            // cross punch
            //Player1.GetComponent<Animator>().SetInteger("Attacking", 4);

        }
        else
        {
            // defending animation
            Player2.GetComponent<Animator>().SetInteger("Defending", 2);

        }
        // reset back to idle animaiton
        InvokeIdle();
    }

    public void Player_2_SwipeDown()
    {
        if (attacking_turn == 1)
        {// attacking animation
            //bool r = false;
            //r = AttackCheck_Player_2();

            //if (r == true)
                Player2.GetComponent<Animator>().SetInteger("Attacking", 1);

            //if (r == false)
                //NotEnoughStamina();

        }
        else
        {
            // defending animation
            Player2.GetComponent<Animator>().SetInteger("Defending", 3);

        }
        // reset back to idle animaiton
        InvokeIdle();

    }

    public void AI_Attack()
    {
        Player2.GetComponent<Animator>().SetInteger("Attack Power", (int)Random.Range(1f, 4f));
        int r = (int)Random.Range(1f, 4f);

        switch (r)
        {
            case 1:
                Player_2_SwipeUp();
                Debug.Log("d case: " + r);
                break;

            case 2:
                Player_2_SwipeLeftRight();
                Debug.Log("d case: " + r);
                break;
            case 3:
                Player_2_SwipeDown();
                Debug.Log("d case: " + r);
                break;
        }
        
        
    }

    public void AI_Defend()
    {
        int r = (int)Random.Range(1f, 4f);

        switch (r)
        {
            case 1:
                Player_2_SwipeUp();
                Debug.Log("d case: " + r);
                break;

            case 2:
                Player_2_SwipeLeftRight();
                Debug.Log("d case: " + r);
                break;
            case 3:
                Player_2_SwipeDown();
                Debug.Log("d case: " + r);
                break;
        }


    }

    public void Decrease_Player_1_Stamina()
    {
        if (Player1.GetComponent<Animator>().GetInteger("Attack Power") == 1) 
        {
            player_1_Stamina -= 10.0f;
        }

        if (Player1.GetComponent<Animator>().GetInteger("Attack Power") == 2)
        {
            player_1_Stamina -= 25.0f;
        }

        if (Player1.GetComponent<Animator>().GetInteger("Attack Power") == 3)
        {
            player_1_Stamina -= 40.0f;
        }
    }

    public void Decrease_Player_2_Stamina()
    {
        if (Player2.GetComponent<Animator>().GetInteger("Attack Power") == 1)
        {
            player_2_Stamina -= 10.0f;
        }

        if (Player2.GetComponent<Animator>().GetInteger("Attack Power") == 2)
        {
            player_2_Stamina -= 25.0f;
        }

        if (Player2.GetComponent<Animator>().GetInteger("Attack Power") == 3)
        {
            player_2_Stamina -= 40.0f;
        }
    }

    public void Player_1_RegainStamina()
    {
        player_1_Stamina += 40.0f;

        if(player_1_Stamina > 100.0f)
        {
            player_1_Stamina = 100.0f;
        }
    }

    public void Player_2_RegainStamina()
    {
        player_2_Stamina += 40.0f;

        if (player_2_Stamina > 100.0f)
        {
            player_2_Stamina = 100.0f;
        }
    }

    public bool AttackCheck_Player_1()
    {
        if (Player1.GetComponent<Animator>().GetInteger("Attack Power") == 1 && player_1_Stamina >= lightAttack_StaminCost)
        {
            return true;
        }
        if (Player1.GetComponent<Animator>().GetInteger("Attack Power") == 2 && player_1_Stamina >= mediumAttack_StaminCost)
        {
            return true;
        }
        if (Player1.GetComponent<Animator>().GetInteger("Attack Power") == 3 && player_1_Stamina >= HeavyAttack_StaminCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AttackCheck_Player_2()
    {
        if (Player2.GetComponent<Animator>().GetInteger("Attack Power") == 1 && player_2_Stamina >= lightAttack_StaminCost)
        {
            return true;
        }
        if (Player2.GetComponent<Animator>().GetInteger("Attack Power") == 2 && player_2_Stamina >= mediumAttack_StaminCost)
        {
            return true;
        }
        if (Player2.GetComponent<Animator>().GetInteger("Attack Power") == 3 && player_2_Stamina >= HeavyAttack_StaminCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void NotEnoughStamina()
    {
        Debug.Log("Not Enough Stamina");

    }

    public void SkipTurn()
    {
        attacksRemaining = 0;
        attacking_turn = SwitchTurnCheck(attacking_turn);

    }

    public void UpdateXP()
    {
        if (winner == 0)
        {
            float x = PlayerPrefs.GetFloat("XP_current");
            x += 100.0f;
            PlayerPrefs.SetFloat("XP_current", x);
        }

    }
    public void HowToPlayer(int x)
    {
        attacking_turn = x;
    }
}
