using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_over : MonoBehaviour
{
    public Button home;
    public Button Shop;
    // Start is called before the first frame update
    void Start()
    {
        home.transform.position = new Vector2(Screen.width/8, Screen.height/9+Screen.height/50);
        Shop.transform.position = new Vector2(Screen.width - 150, Screen.height/9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
