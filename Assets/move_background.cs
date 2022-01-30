using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_background : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool st;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(st==true)
        {
            transform.position = new Vector2(0,-0.2f);
        }else
        {
            transform.position = new Vector2(20f,-0.2f);
        }
        
        rb.velocity = Vector2.left * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -20){
            transform.position = new Vector2(20,-0.2f);
        }
        if(PlayerPrefs.GetString("state")=="paus")
        {
            rb.velocity = Vector2.left * 0;
        }else
        {
            rb.velocity = Vector2.left * 2;
        }
    }
}
