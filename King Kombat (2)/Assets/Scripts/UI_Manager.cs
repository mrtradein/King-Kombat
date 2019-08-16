using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    public GameObject blockOverlay;

    public GameObject defending_UI_Overlay;
    public GameObject winLoseContainer;
    public Text winLoseText;

    public Button lightBtn;
    public Button mediumBtn;
    public Button heavyBtn;

    public Button skipBtn;

    public Text attackPower_txt;

    public RawImage player_1_Stamin_Image;
    public Text player_1_Stamina_Text;

    public RawImage player_2_Stamin_Image;
    public Text player_2_Stamina_Text;

    public GameController gameController;
    public GameObject gameControllerObj;

    public Text timer_Text;
    public Text attacksRemaing_Text;

    public Text player1_Head_Health_Text;
    public Text player1_Body_Health_Text;
    public Text player1_Legs_Health_Text;

    public Text player2_Head_Health_Text;
    public Text player2_Body_Health_Text;
    public Text player2_Legs_Health_Text;


    // Start is called before the first frame update
    void Start()
    {
        winLoseContainer.SetActive(false);
        gameController = gameControllerObj.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTexts();

        ButtonManager();
    }

    public void AttackPowerText_NotSelected()
    {
        attackPower_txt.text = "Attack Power: Not Selected";
        attackPower_txt.color = Color.white;
    }
    public void AttackPowerText_Light()
    {
        attackPower_txt.text = "Attack Power: Light";
        attackPower_txt.color = Color.white;
    }
    public void AttackPowerText_Medium()
    {
        attackPower_txt.text = "Attack Power: Medium";
        attackPower_txt.color = Color.white;

    }
    public void AttackPowerText_Heavy()
    {
        attackPower_txt.text = "Attack Power: Heavy";
        attackPower_txt.color = Color.white;

    }

    public void Player_1_Stamina_Bar()
    {
        player_1_Stamina_Text = GameObject.Find("Fight Scene(Clone)/WorldSpace Canvas (Player 1)/Stamina %").GetComponent<Text>();

        player_1_Stamina_Text.text = "Stamina: "+ gameController.player_1_Stamina.ToString() +"%";

        player_1_Stamin_Image = GameObject.Find("Fight Scene(Clone)/WorldSpace Canvas (Player 1)/Stamina").GetComponent<RawImage>();


        player_1_Stamin_Image.GetComponent<RectTransform>().localScale = new Vector3((gameController.player_1_Stamina / 100), 0.83f, 0.83f);
    }

    public void Player_2_Stamina_Bar()
    {
        //player_2_Stamina_Text.text = "Stamina: " + gameController.player_2_Stamina.ToString() + "%";
        //player_2_Stamin_Image.GetComponent<RectTransform>().localScale = new Vector3((gameController.player_2_Stamina / 100), 0.83f, 0.83f);
    }

    public void ButtonManager()
    {


        if (gameController.attacking_turn == 0)
        {
            skipBtn.GetComponent<Button>().interactable = true;


            // player 1
            if (gameController.player_1_Stamina < gameController.lightAttack_StaminCost)
            {
                lightBtn.GetComponent<Button>().interactable = false;
            }
            else
            {
                lightBtn.GetComponent<Button>().interactable = true;
            }

            if (gameController.player_1_Stamina < gameController.mediumAttack_StaminCost)
            {
                mediumBtn.GetComponent<Button>().interactable = false;
            }
            else
            {
                mediumBtn.GetComponent<Button>().interactable = true;
            }

            if (gameController.player_1_Stamina < gameController.HeavyAttack_StaminCost)
            {
                heavyBtn.GetComponent<Button>().interactable = false;
            }
            else
            {
                heavyBtn.GetComponent<Button>().interactable = true;

            }
        }
        else
        {
            skipBtn.GetComponent<Button>().interactable = false;

        }

        //if (gameController.attacking_turn == 0)
        //{
        //    // player 2
        //    if (gameController.player_2_Stamina < gameController.lightAttack_StaminCost)
        //    {
        //        lightBtn.GetComponent<Button>().interactable = false;
        //    }
        //    else
        //    {
        //        lightBtn.GetComponent<Button>().interactable = true;
        //    }

        //    if (gameController.player_2_Stamina < gameController.mediumAttack_StaminCost)
        //    {
        //        mediumBtn.GetComponent<Button>().interactable = false;
        //    }
        //    else
        //    {
        //        mediumBtn.GetComponent<Button>().interactable = true;
        //    }
        //    if (gameController.player_2_Stamina < gameController.HeavyAttack_StaminCost)
        //    {
        //        heavyBtn.GetComponent<Button>().interactable = false;
        //    }
        //    else
        //    {
        //        heavyBtn.GetComponent<Button>().interactable = true;

        //    }
        //}
    }

    public void WinLoseContainer_On()
    {
        winLoseContainer.SetActive(true);
        if(gameController.winner == 0)
        {
            winLoseText.text = "Player 1 Wins";

        }
        else
        {
            winLoseText.text = "Player 2 Wins";

        }
    }

    public void BlockOverlay_ON()
    {
        blockOverlay.GetComponent<Animator>().SetBool("On", true);
        Invoke("BlockOverlay_OFF", 0.2f);
    }
    public void BlockOverlay_OFF()
    {
        blockOverlay.GetComponent<Animator>().SetBool("On", false);
    }

    public void UpdateTexts()
    {

        player1_Head_Health_Text = GameObject.Find("Fight Scene(Clone)/WorldSpace Canvas (Player 1)/Head/Head").GetComponent<Text>();
        player1_Body_Health_Text = GameObject.Find("Fight Scene(Clone)/WorldSpace Canvas (Player 1)/Body/Body").GetComponent<Text>();
        player1_Legs_Health_Text = GameObject.Find("Fight Scene(Clone)/WorldSpace Canvas (Player 1)/Legs/Legs").GetComponent<Text>();

        player2_Head_Health_Text = GameObject.Find("Fight Scene(Clone)/WorldSpace Canvas (Player 2)/Head/Head").GetComponent<Text>();
        player2_Body_Health_Text = GameObject.Find("Fight Scene(Clone)/WorldSpace Canvas (Player 2)/Body/Body").GetComponent<Text>();
        player2_Legs_Health_Text = GameObject.Find("Fight Scene(Clone)/WorldSpace Canvas (Player 2)/Legs/Legs").GetComponent<Text>();

        timer_Text.text = "Timer: " + gameController.timeRemaining.ToString("0");
        attacksRemaing_Text.text = "Attacks left: " + gameController.attacksRemaining.ToString("0");

        player1_Head_Health_Text.text = "Head: " + gameController.player1_Head_Health.ToString("0.00") + "%";
        player1_Body_Health_Text.text = "Body: " + gameController.player1_Body_Health.ToString("0.00") + "%";
        player1_Legs_Health_Text.text = "Legs: " + gameController.player1_Legs_Health.ToString("0.00") + "%";

        player2_Head_Health_Text.text = "Head: " + gameController.player2_Head_Health.ToString("0.00") + "%";
        player2_Body_Health_Text.text = "Body: " + gameController.player2_Body_Health.ToString("0.00") + "%";
        player2_Legs_Health_Text.text = "Legs: " + gameController.player2_Legs_Health.ToString("0.00") + "%";

        Player_1_Stamina_Bar();
        Player_2_Stamina_Bar();
    }

}
