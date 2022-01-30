using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move_frog : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;
    public Sprite[] newSprite2;

    private Rigidbody2D rb;
    public float speed = 25;
    private float moveinput;

    private int pos_now = 2;
    private int pos_next = 0;
    private int hight = Screen.height * 50 / 100;
    private bool bee_active;
    public Vector2 vec = new Vector2();
    public Vector2 vec2 = new Vector2();
    public Vector2 vec_empty = new Vector2(0,0);
    
    public Button btn_up;
    public Button btn_down;
    public Button btn_menu;
    public Text texting;
    int p;
    public Vector2 position;

    void Start()
    {
        int.TryParse(PlayerPrefs.GetString("skin"), out p);
        if(PlayerPrefs.GetString("skin")== null||PlayerPrefs.GetString("skin")== "")
        {
            p=0;
            PlayerPrefs.SetString("skin","0");
        }      
        btn_menu.transform.position = new Vector2(Screen.width -150, Screen.height -80);
        if(PlayerPrefs.GetString("btn_pos")=="r"){
            btn_down.transform.position = new Vector2(Screen.width- 150,Screen.height/2 -Screen.height/4);
            btn_up.transform.position = new Vector2(Screen.width- 150,Screen.height/2 +Screen.height/7);    
        }else
        {
            btn_down.transform.position = new Vector2(150,Screen.height/2 -Screen.height/4);
            btn_up.transform.position = new Vector2(150,Screen.height/2 +Screen.height/7);
        }
        texting.transform.position = new Vector2((Screen.width -300),( Screen.height -100));
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newSprite[p];
        switch (pos_now){
            case 1:
            transform.position = new Vector2(-4,-3);
            break;
            case 2:
            transform.position = new Vector2(-4,0);
            break;
            case 3:
            transform.position = new Vector2(-4,3);
            break;
        }
        rb = GetComponent<Rigidbody2D>();
        texting.text ="";
    }

    void Update(){
        position = new Vector2(transform.position.x, transform.position.y);
        if(transform.position.y == 0 || transform.position.y == -3 || transform.position.y == 3 ){
            if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
                Touch touch = Input.GetTouch(0);
                vec = touch.position;
            }
            else if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved){
                Touch touch = Input.GetTouch(0);
                vec2 = touch.position;
                //texting.text = $"{Mathf.Abs(vec.x)} ; {Mathf.Abs(vec.y)}\n{Mathf.Abs(vec2.x)} ; {Mathf.Abs(vec2.y)}";
            }
            if(vec2.y > (Screen.height-(Screen.height *.2)) || vec2.x > (Screen.width-(Screen.width *.2))){
                vec = vec_empty;
                vec2 = vec_empty;
            }
        }            
            /*if(vec.x > Screen.width || vec.x < Screen.width||vec2.x > Screen.width || vec2.x < Screen.width ||vec.y > Screen.height || vec.y < Screen.height||vec2.y > Screen.height || vec.y < Screen.height){
                vec = vec_empty;
                vec2 = vec_empty;
            }
            //move frog
            if(Input.GetKeyDown("w") && pos_now != 3 || pos_now != 3 && Mathf.Abs(vec2.y) - Mathf.Abs(vec.y) > hight ){
                spriteRenderer.sprite = newSprite2;
                pos_next = pos_now +1;
                rb.velocity = Vector2.up * speed;
            } 
            else if(Input.GetKeyDown("s") && pos_now != 1||pos_now != 1 && Mathf.Abs(vec.y) - Mathf.Abs(vec2.y) > hight ){
                spriteRenderer.sprite = newSprite2;
                pos_next = pos_now -1;
                rb.velocity = Vector2.up * -speed;
            }  
            */
            if(/*pos_now != 3 && vec2.y - vec.y > hight ||*/ pos_now != 3 && PlayerPrefs.GetString("move") == "up"){
                pos_next = pos_now +1;
                rb.velocity = Vector2.up * speed;
                //up
            }
            if(/*pos_now != 1 && vec.y - vec2.y > hight || */pos_now != 1 && PlayerPrefs.GetString("move") == "down"){
                pos_next = pos_now -1;
                rb.velocity = Vector2.up * -speed;
                //down
            }

            switch(pos_next){
                case 1:
                if(transform.position.y <= -3){
                    spriteRenderer.sprite = newSprite[p];
                    rb.velocity = Vector2.up * 0;
                    pos_now = 1;
                    transform.position = new Vector2(-4,-3);
                    vec = vec_empty;
                    vec2 = vec_empty;
                    PlayerPrefs.SetString("move" ,"");
                }
                break;
                case 2:
                if(transform.position.y >= -1 && transform.position.y <= 1 ){
                    spriteRenderer.sprite = newSprite[p];
                    rb.velocity = Vector2.up * 0;
                    pos_now =2;
                    transform.position = new Vector2(-4,0);
                    vec = vec_empty;
                    vec2 = vec_empty;
                    PlayerPrefs.SetString("move" ,"");
                }
                break;
                case 3:
                if(transform.position.y >= 3){
                    spriteRenderer.sprite = newSprite[p];
                    rb.velocity = Vector2.up * 0;
                    pos_now = 3;
                    transform.position = new Vector2(-4,3);
                    vec = vec_empty;
                    vec2 = vec_empty;
                    PlayerPrefs.SetString("move" ,"");
                }
                break;
            }        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.ToString() == "smile(Clone) (UnityEngine.BoxCollider2D)" || other.ToString() == "smile(Clone) (UnityEngine.CircleCollider2D)"|| other.ToString() =="1635349380423(Clone) (UnityEngine.CircleCollider2D)")
        {
            try
            {
                int i = PlayerPrefs.GetInt("highscore");
                int j = PlayerPrefs.GetInt("coin count");
                if(j > i)
                {
                    PlayerPrefs.SetInt("highscore", j);
                }
            }
            catch
            {
                PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("coin count"));
            }
            Debug.Log(PlayerPrefs.GetInt("highscore"));
            Destroy(this.gameObject);
            SceneManager.LoadScene("gameover");
        }
    }
}
