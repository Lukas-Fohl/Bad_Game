using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shop : MonoBehaviour
{
    public Button home;
    public Button last;
    public Button next;
    private Rigidbody2D rb;
    public GameObject[] Cards;
    private int cur_pos;
    public int pos;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("skin_able","1");
        score.transform.position = new Vector2(Screen.width-5000, Screen.height-5000);
        if(PlayerPrefs.GetString("skins") == "")
        {
            string bought ="";
            for(int i =0; i< Cards.Length; i++)
            {
                bought+="0-";
            }
            PlayerPrefs.SetString("skins", bought);
        }
        last.transform.position = new Vector2(10000, 10000);
        next.transform.position = new Vector2(10000, 10000);
        home.transform.position = new Vector2(10000, 10000);
        PlayerPrefs.SetInt("shop_place", 1);
        transform.position = new Vector2(0,0);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * 10;
        cur_pos = PlayerPrefs.GetInt("shop_place")+1;
        for(int i = 0; i<Cards.Length;i++)
                {
                    try
                    {
                        Cards[i] = Instantiate(Cards[i]) as GameObject;   
                        switch(i%5)
                        {
                            case 1:
                                Cards[i].SetActive(true);
                                Cards[i].SetActive(false);
                                Cards[i].transform.position = new Vector2(-2,2);  
                                Cards[i].transform.Rotate(0,0,Random.Range(-30,30)); 
                            break;
                            case 2:
                                Cards[i].SetActive(true);
                                Cards[i].SetActive(false);
                                Cards[i].transform.position = new Vector2(0,2); 
                                Cards[i].transform.Rotate(0,0,Random.Range(-30,30)); 
                            break;
                            case 3:
                                Cards[i].SetActive(true);
                                Cards[i].SetActive(false);
                                Cards[i].transform.position = new Vector2(2,2);  
                                Cards[i].transform.Rotate(0,0,Random.Range(-30,30)); 
                            break;
                            case 4:
                                Cards[i].SetActive(true);
                                Cards[i].SetActive(false);
                                Cards[i].transform.position = new Vector2(5,2);  
                                Cards[i].transform.Rotate(0,0,Random.Range(-30,30)); 
                            break;
                            case 0:
                                Cards[i].SetActive(true);
                                Cards[i].SetActive(false);
                                Cards[i].transform.position = new Vector2(-5,2);  
                                Cards[i].transform.Rotate(0,0,Random.Range(-30,30));
                            break;
                        }     
                    }
                    catch
                    {
                        Debug.Log("lol");
                    }
                }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 12.5 && transform.position.y <= 14.5 )
        {
            score.text = $"score: {PlayerPrefs.GetInt("score")}";
            int f =Cards.Length/5;
            if(Cards.Length%5!=0 && Cards.Length >5)
                f++;
            PlayerPrefs.SetInt("lenght",f);
            last.transform.position = new Vector2(Screen.width/2 -100, 100);
            next.transform.position = new Vector2(Screen.width/2 +100, 100);
            home.transform.position = new Vector2(100, Screen.height-200);
            //transform.position = new Vector2(0,14);
            rb.velocity = Vector2.up * 0;
            score.transform.position = new Vector2(Screen.width-200, Screen.height-50);
            pos = PlayerPrefs.GetInt("shop_place");
            if(pos != cur_pos)
            {
                Debug.Log(PlayerPrefs.GetString("skins"));
                cur_pos = pos;
                GameObject[] goj = GameObject.FindGameObjectsWithTag("card");
                for(int i = 0; i < goj.Length; i++)
                {
                    goj[i].SetActive(false);
                }                
                for(int i = pos*5-5; i<pos*5;i++)
                {
                    try
                    {   
                        switch(i%5)
                        {
                            case 1:
                                Cards[i].SetActive(true);
                            break;
                            case 2:
                                Cards[i].SetActive(true); 
                            break;
                            case 3:
                                Cards[i].SetActive(true);
                            break;
                            case 4:
                                Cards[i].SetActive(true); 
                            break;
                            case 0:
                                Cards[i].SetActive(true);
                            break;
                        }     
                    }
                    catch
                    {
                        
                    }
                    if(PlayerPrefs.GetInt("shop_place") == 1)
                    {
                        last.interactable = false;
                    }else
                    {
                        last.interactable = true;
                    }
                    if(PlayerPrefs.GetInt("shop_place") == PlayerPrefs.GetInt("lenght"))
                    {
                        next.interactable = false;
                    }else
                    {
                        next.interactable = true;
                    }
                } 
            }    
        }  
        if(PlayerPrefs.GetString("shop") == "1")
        {
            score.text = "";
            last.transform.position = new Vector2(Screen.width/2 -100, 10000);
            next.transform.position = new Vector2(Screen.width/2 +100, 10000);
            home.transform.position = new Vector2(100, Screen.height-10000);
            rb.velocity = Vector2.up * -10;
            if(transform.position.y <= 0)
            {
                SceneManager.LoadScene("Scene2");
                PlayerPrefs.SetString("shop", "0");
            }
            if(transform.position.y <= 5)
            {
                GameObject[] goj = GameObject.FindGameObjectsWithTag("card");
                for(int i = 0; i < goj.Length; i++)
                {
                    goj[i].SetActive(false);
                }
            }
        } 
    }
}
