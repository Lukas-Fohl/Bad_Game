using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public count_coin cc;

    void Start()
    {
        try{
            cc = FindObjectOfType<count_coin>();
            speed = speed + ((cc.counter)/25);
        }catch{
        
        }
            rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-speed, 0);
    }

    void Update()
    {
        if(transform.position.x < -10){
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if(PlayerPrefs.GetString("state") == "paus")
        {
            rb.velocity = new Vector2(0, 0);
        }else if(PlayerPrefs.GetString("state") =="play")
        {
            try{
        cc = FindObjectOfType<count_coin>();
        if(speed != 10 + (cc.counter)/25 )
        {
            speed = speed ++;
        }
        }catch{
        
        }
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        }
    }
}
