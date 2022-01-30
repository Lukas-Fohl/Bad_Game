using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {     
        Debug.Log(other.ToString());
        if(other.ToString() !="")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);  
        } 
    }
}
