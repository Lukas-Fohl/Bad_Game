using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skin : MonoBehaviour
{
    // Start is called before the first frame update
    public Button action;
    public int id;
    void Start()
    {
        switch(transform.position.x)
        {
            case -5:
            action.transform.position = new Vector2(Screen.width/6,Screen.height/2-100);
            break;
            case -2:
            action.transform.position = new Vector2((Screen.width/6) *2,Screen.height/2-100);
            break;
            case 0:
            action.transform.position = new Vector2((Screen.width/6) *3,Screen.height/2-100);
            break;
            case 2:
            action.transform.position = new Vector2((Screen.width/6) *4,Screen.height/2-100);
            break;
            case 5:
            action.transform.position = new Vector2((Screen.width/6) *5,Screen.height/2-100);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("skin") == id.ToString())
        {
            action.interactable = false;
        }else
        {
            action.interactable = true;
        }
        if(PlayerPrefs.GetString("skin") == ""||PlayerPrefs.GetString("skin") == null)
        {
            PlayerPrefs.SetString("skin","0");
        }
    }
    public void on_click()
    {
        PlayerPrefs.SetString("skin", id.ToString());
    }
}
