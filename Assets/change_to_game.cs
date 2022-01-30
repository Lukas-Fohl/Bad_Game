using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_to_game : MonoBehaviour
{
    public void click(){
        PlayerPrefs.SetInt("coin count",0);
        SceneManager.LoadScene("SampleScene");
    }
    public void move_up()
    {
        PlayerPrefs.SetString("move", "up");
    }
    public void move_down()
    {
        PlayerPrefs.SetString("move", "down");
    }
    public void menu_click()
    {
        PlayerPrefs.SetString("state", "paus");
    }
    public void play_click()
    {
        PlayerPrefs.SetString("state", "play");
    }
    public void home_click()
    {
        PlayerPrefs.SetString("shop", "1");
    }
    public void Home2_cick()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void start_click()
    {
        PlayerPrefs.SetString("Menu","off");
    }
    public void left_click()
    {
        PlayerPrefs.SetString("btn_pos","l");
    }
    public void right_click()
    {
        PlayerPrefs.SetString("btn_pos","r");
    }
    public void left_shop()
    {
        if(PlayerPrefs.GetInt("shop_place") > 1)
        {
            PlayerPrefs.SetInt("shop_place", PlayerPrefs.GetInt("shop_place") -1);
        }
    }
    public void right_shop()
    {
        if(PlayerPrefs.GetInt("shop_place") < PlayerPrefs.GetInt("lenght"))
        {
            PlayerPrefs.SetInt("shop_place", PlayerPrefs.GetInt("shop_place") + 1);
        }
    }
    public void skin_click()
    {
        SceneManager.LoadScene("skins");
    }
    public void shop_click()
    {
        SceneManager.LoadScene("shop");
    }
}
