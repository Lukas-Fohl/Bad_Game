using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_but_not : MonoBehaviour
{
    // Start is called before the first frame update
    public count_coin c_c;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 100&& gameObject.ToString().Contains("clone"))
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
    if(other.ToString() =="1635349380423(Clone) (UnityEngine.CircleCollider2D)")
        {
            other.gameObject.SetActive(false);
            Destroy(other);
            c_c = FindObjectOfType<count_coin>();
            c_c.counter = c_c.counter+10;
        }
    }
}
