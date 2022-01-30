using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btn_menu; 
    public Button btn_shop;
    public Button skin_btn;
    void Start()
    {
        transform.position = new Vector2(-50,-50);
        btn_menu.transform.position = new Vector2(Screen.width -100, Screen.height -100);
        btn_shop.transform.position = new Vector2(Screen.width -100, 100);
        skin_btn.transform.position = new Vector2(Screen.width -100, Screen.height/2);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("skin_able")=="1")
        {
            skin_btn.enabled = true;
        }else if(PlayerPrefs.GetString("skin_able")==""||PlayerPrefs.GetString("skin_able")==null)
        {
            skin_btn.enabled = false;
        }
    }
}
