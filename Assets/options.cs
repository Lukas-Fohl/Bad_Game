using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class options : MonoBehaviour
{
    // Start is called before the first frame update
    public Button start_btn;
    public Text start_txt;
    public Button back_to_game;

    public Button left_btn;
    public Button right_btn;
    public Text btn_pos;
    void Start()
    {
        PlayerPrefs.SetString("Menu","off");
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("Menu") == "on")
        {
            transform.position = new Vector2(0,0);
            back_to_game.transform.position = new Vector2((Screen.width/2) -(Screen.width/100 * 15), (Screen.height/2) + (Screen.height /100 *20));
            start_txt.transform.position = new Vector2(Screen.width*2, Screen.height*2);
            start_btn.transform.position = new Vector2(Screen.width*2, Screen.height*2);
            left_btn.transform.position = new Vector2(Screen.width/2,Screen.height /2);
            right_btn.transform.position = new Vector2(Screen.width/2+ (Screen.width/100 *15),Screen.height/2);
            btn_pos.transform.position = new Vector2(Screen.width/2 - (Screen.width/100 *15),Screen.height/2);
        }
        else
        {
            transform.position = new Vector2(-10,-10);
            back_to_game.transform.position = new Vector2((Screen.width) -(Screen.width/100 * 24), (Screen.height) + (Screen.height /100 *20));
            start_txt.transform.position = new Vector2(Screen.width/2, Screen.height/2);
            start_btn.transform.position = new Vector2(Screen.width/2, Screen.height/2);
            left_btn.transform.position = new Vector2(Screen.width*2,Screen.height *2);
            right_btn.transform.position = new Vector2(Screen.width*2,Screen.height*2);
            btn_pos.transform.position = new Vector2(Screen.width*2,Screen.height*2);
        }
    }
    public void right_click()
    {
        PlayerPrefs.SetString("btn_pos","r");
        right_btn.interactable = false;
        left_btn.interactable = true;
    }
    public void left_click()
    {
        PlayerPrefs.SetString("btn_pos","l");
        left_btn.interactable= false;
        right_btn.interactable =true;
    }
    public void start_click()
    {
        PlayerPrefs.SetString("Menu","off");
    }
    public void menu_click()
    {
        PlayerPrefs.SetString("Menu","on");
    }
    public void shop_click()
    {
        PlayerPrefs.SetString("Shop","on");
        SceneManager.LoadScene("shop");
    }
}

