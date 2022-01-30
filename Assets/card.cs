using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class card : MonoBehaviour
{
    public int id;
    public bool bought;
    public Button btn;
    public int price;
    // Start is called before the first frame update
    void Start()
    {
        btn.GetComponentInChildren<Text>().text = $"buy for {price}";
        bought = false;
        try
        {
            //PlayerPrefs.SetString($"skins{id}", "0");//muss noch weg
            if(PlayerPrefs.GetString($"skins{id}") == "1" || bought == true)
            {
                bought = true;
                btn.interactable = false;
            }
        }catch
        {
            PlayerPrefs.SetString($"skins{id}", "0");
        }
        switch(transform.position.x)
        {
            case -5:
            btn.transform.position = new Vector2(Screen.width/6,Screen.height/2-100);
            break;
            case -2:
            btn.transform.position = new Vector2((Screen.width/6) *2,Screen.height/2-100);
            break;
            case 0:
            btn.transform.position = new Vector2((Screen.width/6) *3,Screen.height/2-100);
            break;
            case 2:
            btn.transform.position = new Vector2((Screen.width/6) *4,Screen.height/2-100);
            break;
            case 5:
            btn.transform.position = new Vector2((Screen.width/6) *5,Screen.height/2-100);
            break;
        }
        if(id == 0) 
        {
            bought =true;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString($"skins{id}") == "1" || id==0)
        {
            bought = true;
            btn.interactable = false;
            string[] list = PlayerPrefs.GetString("skins").Split('-');
        if(bought == true)
        {
            list[id] = "1";
        }else
        {
            list[id] = "0";
        }
        string send_list="";
        foreach(string a in list)
        {
            if(a!="")
            {
            send_list +=a+"-";
            }
        }
        PlayerPrefs.SetString("skins",send_list);
        }
    }
    public void buy_click()
    {
        //get coin count than set activ 
        if(price <= PlayerPrefs.GetInt("score"))
        {
        PlayerPrefs.SetString($"skins{id}","1");
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score")-price);
        }
    }
}
