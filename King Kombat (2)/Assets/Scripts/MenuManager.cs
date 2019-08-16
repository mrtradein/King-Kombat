using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : MonoBehaviour
{
    public Text XP_current_text;
    public Text XP_until_next_level_text;
    public Text level_current_text;
    public Text loot_boxes_text;

    public Image XP_bar_image;


    public XPManager xpm;
    public GameObject xpm_obj;

    // Start is called before the first frame update
    void Start()
    {
        xpm_obj = GameObject.Find("XP Manager");
        xpm = xpm_obj.GetComponent<XPManager>();


    }

    private void Update()
    {
        UpdateText();

    }

    public void UpdateText()
    {
        // update menu texts
        XP_current_text.text = "XP: " + xpm.XP_current.ToString();
        XP_until_next_level_text.text = "XP Until Next Level: " + xpm.XP_until_next_level.ToString();
        level_current_text.text = "Level: " + xpm.level_current.ToString();
        //loot_boxes_text.text = xpm.XP_current.ToString();

        // change scale of XP Bar
        XP_bar_image.GetComponent<RectTransform>().localScale = new Vector3((xpm.XP_current / xpm.XP_until_next_level), 1.0f, 1.0f);
        //Debug.Log((float)(xpm.XP_current / xpm.XP_until_next_level));

    }
}
