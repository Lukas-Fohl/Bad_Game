using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject plattprefab;
    public GameObject coinprefab;
    public GameObject Enemy;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(move_platt());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(plattprefab) as GameObject;
        GameObject b = Instantiate(coinprefab) as GameObject;
        GameObject c = Instantiate(plattprefab) as GameObject;
        GameObject d = Instantiate(plattprefab) as GameObject;
        GameObject e = Instantiate(plattprefab) as GameObject;
        GameObject coin2 = Instantiate(coinprefab) as GameObject;
        GameObject coin3 = Instantiate(coinprefab) as GameObject;
        GameObject enemy = Instantiate(Enemy) as GameObject;
        int i = Random.Range(1,14);
        int j = Random.Range(1,3);
        switch (i){
            case 1:
            a.transform.position = new Vector2(20, -3);
            if(j == 1)
                b.transform.position = new Vector2(20, 0);
            else
                b.transform.position = new Vector2(20, 3);
            break;
            case 2:
            a.transform.position = new Vector2(20, 0);
            if(j == 1)
                b.transform.position = new Vector2(20, -3);
            else
                b.transform.position = new Vector2(20, 3);
            break;
            case 3:
            a.transform.position = new Vector2(20, 3);
            if(j == 1)
                b.transform.position = new Vector2(20, 0);
            else
                b.transform.position = new Vector2(20, -3);
            break;
            case 4:
            //clear
            if(j == 1){
                a.transform.position = new Vector2(20, 3);
                c.transform.position = new Vector2(20, -3);
            }else{

            }
            break;
            case 5:
            a.transform.position = new Vector2(20, 3);
            c.transform.position = new Vector2(20, 0);
            break;
            case 6:
            a.transform.position = new Vector2(20, -3);
            c.transform.position = new Vector2(20, 0);
            break;
            case 7:
            if(j == 1)
            {
            b.transform.position = new Vector2(20, -3);
            coin2.transform.position = new Vector2(20, 0);
            coin3.transform.position = new Vector2(20, 3);
            }else {
            a.transform.position = new Vector2(20, -3);
            }
            break;
            case 8:
            b.transform.position = new Vector2(18, 0);
            coin2.transform.position = new Vector2(20, 0);
            coin3.transform.position = new Vector2(22, 0);
            break;
            case 9:
            a.transform.position = new Vector2(20, 3);
            break;
            case 10:
            a.transform.position = new Vector2(20, 0);
            break; 
            case 11:
            enemy.transform.position = new Vector2(20,3);
            break;
            case 12:
            enemy.transform.position = new Vector2(20,0);
            break;
            case 13:
            enemy.transform.position = new Vector2(20,-3);
            break;
        }
    }
    IEnumerator move_platt()
    {
        respawnTime = 3;
        while (true)
        {
                yield return new WaitForSeconds(respawnTime);
                if(PlayerPrefs.GetString("state") == "play")
                {
                    spawnEnemy();
                }
                respawnTime = .8f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {     
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);   
    }
}
