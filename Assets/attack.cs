using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class attack : MonoBehaviour
{

    bool perm;
    public move_frog mf;
    public GameObject ring;
    public Button Button;
    public GameObject attack_prefab;
    // Start is called before the first frame update
    void Start()
    {
        perm = true;
        transform.position = new Vector2(100,100);
        if(PlayerPrefs.GetString("btn_pos")=="r")
        {
            Button.transform.position = new Vector2(0,Screen.height/4.5f);
        }            
        else
        {
            Button.transform.position = new Vector2(Screen.width,Screen.height/4.5f);
        }
        ring.transform.position = new Vector2(-8,3);
        mf = FindObjectOfType<move_frog>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            //Touch();
        }
        if(PlayerPrefs.GetString("state")=="paus")
        {
            Button.transform.position = new Vector2(10000,0);
        }else
        {
            if(PlayerPrefs.GetString("btn_pos")=="l")
            {
                Button.transform.position = new Vector2(Screen.width,Screen.height/4);
            }            
            else
            {
                Button.transform.position = new Vector2(0,Screen.height/4);
            }
        }
    }
    /*
    public void Touch()
    {
        Vector2 pos = mf.position;
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began && perm == true)
            {
                if(touch.position.x>Screen.width/2)
                {
                    GameObject attack_prefab_ = Instantiate(attack_prefab) as GameObject;
                    attack_prefab_.transform.position = new Vector2(pos.x+1,pos.y);
                    perm = false;
                    //StartCoroutine(place());
                }
            }
    }
    */
    public void touch2()
    {
        if(perm==true)
        {
            perm = false;
            Vector2 pos = mf.position;
            GameObject attack_prefab_ = Instantiate(attack_prefab) as GameObject;
            attack_prefab_.transform.position = new Vector2(pos.x+1,pos.y);
            StartCoroutine(place(attack_prefab_));
        }
    }
    IEnumerator place(GameObject attack_prefab)
    {
        try{ring.transform.position = new Vector2(100,100);}catch{}
        yield return new WaitForSeconds(.5f);
        try{attack_prefab.transform.position = new Vector2(100,100);}catch{}
        StartCoroutine(able(attack_prefab));
    }
    IEnumerator able(GameObject attack_prefab)
    {
        while(PlayerPrefs.GetString("state")=="paus")
        {
            yield return new WaitForSeconds(.10f);    
        }
        yield return new WaitForSeconds(.75f);
        while(PlayerPrefs.GetString("state")=="paus")
        {
            yield return new WaitForSeconds(.10f);    
        }
        try{ring.transform.position = new Vector2(-8,3);}catch{}
        perm = true;
        try{attack_prefab.transform.position = new Vector2(100,100);}catch{}
    }
}
