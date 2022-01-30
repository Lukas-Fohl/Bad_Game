using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count_coin : MonoBehaviour
{
    public int counter = 0;
    public Text texting;
    void Start()
    {
        texting.transform.position = new Vector2((Screen.width -400),( Screen.height -130));
        PlayerPrefs.SetInt("coin count", 0);
    }
    void Update()
    {
        
        texting.text = $"{counter.ToString()} points";
        PlayerPrefs.SetInt("coin count", counter);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {     
        texting.transform.position = new Vector2((Screen.width -400),( Screen.height -115));
        if(other.gameObject.ToString().Contains("Coin_fertig")){
            counter++;   
        }
        if(counter == 0)
        {
            texting.text = $"{counter.ToString()} points";
        }else if(counter == 1)
        {
            texting.text = $"{counter.ToString()} point";
        }
        else if( counter <= 100)
            texting.text = $"{counter.ToString()} points";
        else if ( counter <= 200)  
            texting.text = $"{counter.ToString()} points";
            else 
            texting.text = $"{counter.ToString()} points";
        other.gameObject.SetActive(false);
        PlayerPrefs.SetInt("coin count", counter);
        Destroy(other.gameObject);
    }
}
