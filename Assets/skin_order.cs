using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skin_order : MonoBehaviour
{
    public Button btn_home;
    public Button next_;
    public Button last_;
    public GameObject[] cards;
    int pos_now = 1;
    int pos = 2;
    string bought;
    // Start is called before the first frame update
    void Start()
    {
        last_.transform.position = new Vector2(Screen.width/2 -100,100);
        next_.transform.position = new Vector2(Screen.width/2 +100,100);
        btn_home.transform.position = new Vector2(100, Screen.height-200);
        string[] skins = PlayerPrefs.GetString("skins").Split('-');
        //skins[0] ="1";
        bought ="";
        for(int i = 0;i < skins.Length;i++)
        {
            if(skins[i] == "1")
            {
                bought += "-"+i;
            }
        }
        //from 0 to 11
        Debug.Log(bought);
        string[] ll = bought.Split('-');
        for(int i=1;i<ll.Length;i++)
        {
            try
            {
                int j;
                int.TryParse(ll[i], out j);
                switch((i+9)%5)
                {
                    case 0:
                        cards[j] = Instantiate(cards[j]) as GameObject;   
                        cards[j].SetActive(true);
                        cards[j].SetActive(false);
                        cards[j].transform.position = new Vector2(-5,2);  
                    break;
                    case 1:
                        cards[j] = Instantiate(cards[j]) as GameObject;   
                        cards[j].SetActive(true);
                        cards[j].SetActive(false);
                        cards[j].transform.position = new Vector2(-2,2);  
                    break;
                    case 2:
                        cards[j] = Instantiate(cards[j]) as GameObject;   
                        cards[j].SetActive(true);
                        cards[j].SetActive(false);
                        cards[j].transform.position = new Vector2(0,2);  
                    break;
                    case 3:
                        cards[j] = Instantiate(cards[j]) as GameObject;   
                        cards[j].SetActive(true);
                        cards[j].SetActive(false);
                        cards[j].transform.position = new Vector2(2,2);  
                    break;
                    case 4:
                        cards[j] = Instantiate(cards[j]) as GameObject;   
                        cards[j].SetActive(true);
                        cards[j].SetActive(false);
                        cards[j].transform.position = new Vector2(5,2);  
                    break;
                    default:
                        cards[j] = Instantiate(cards[j]) as GameObject;   
                        cards[j].SetActive(true);
                        cards[j].SetActive(false);
                        cards[j].transform.position = new Vector2(-5,2);  
                    break;
                }
            }catch
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pos != pos_now)
        {
        pos = pos_now;
        GameObject[] goj = GameObject.FindGameObjectsWithTag("card");
            for(int i = 0; i < goj.Length; i++)
            {
                goj[i].SetActive(false);
            } 
            for(int i = pos*5-5+1; i<pos*5+1;i++)
                {
                    try
                    {   
                        string[] ll = bought.Split('-');
                        int j;
                        int.TryParse(ll[i], out j);
                        switch((i+11)%5)
                        {
                            case 1:
                                cards[j].SetActive(true);
                            break;
                            case 2:
                                cards[j].SetActive(true); 
                            break;
                            case 3:
                                cards[j].SetActive(true);
                            break;
                            case 4:
                                cards[j].SetActive(true); 
                            break;
                            case 0:
                                cards[j].SetActive(true);
                            break;
                            default:
                                cards[j].SetActive(true);
                            break;
                        }     
                    }
                    catch
                    {
                        
                    }
                } 
            if(pos_now > 1)
                last_.interactable = true;
            else
                last_.interactable = false;
            string[] jj = bought.Split('-');
            int k = (jj.Length-1)/5;
            if(jj.Length-1%5!=0 && jj.Length-1>5)
                k++;
            if(pos_now < k)
                next_.interactable = true;
            else
                next_.interactable = false;
        }
    }
    public void next()
    {
        string[] ll = bought.Split('-');
        int i = (ll.Length-1)/5;
        if(ll.Length-1%5!=0 && ll.Length-1>5)
            i++;
        if(pos_now < i)
        {
            pos_now++;
        }
    }
    public void last()
    {
        if(pos_now > 1)
        {
            pos_now--;
        }
    }
}
