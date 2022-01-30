using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class paus_menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn_up;
    public Button btn_down;
    public Button btn_menu;
    public Text menu_txt;
    public Button play;
    public Button home;
    void Start()
    {
        PlayerPrefs.SetString("state","play");
        transform.position = new Vector2(-500, -500);
        menu_txt.transform.position = new Vector2(Screen.width +100,Screen.height+100);
        play.transform.position = new Vector2(Screen.width+100,Screen.height+100);
        home.transform.position = new Vector2(Screen.width+100,Screen.height+100);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("state") == "paus")
        {
            transform.position = new Vector2(0, 0);
            btn_up.interactable = false;
            btn_down.interactable = false;
            btn_menu.interactable = false;
            menu_txt.transform.position = new Vector2(Screen.width /2 ,Screen.height/2 +Screen.height/10);
            menu_txt.text = $"your score is \n {PlayerPrefs.GetInt("coin count")}";
            play.transform.position = new Vector2(Screen.width /2 -50, Screen.height /2 -50);
            home.transform.position = new Vector2(Screen.width /2 +50, Screen.height /2 -50);
        }else if(PlayerPrefs.GetString("state")=="play")
        {
            transform.position = new Vector2(-500, -500);
            btn_up.interactable = true;
            btn_down.interactable = true;
            btn_menu.interactable = true;
            menu_txt.transform.position = new Vector2(Screen.width +100,Screen.height+100);
            play.transform.position = new Vector2(Screen.width +100,Screen.height+100);
            home.transform.position = new Vector2(Screen.width +100,Screen.height+100);
        }
    }
}
