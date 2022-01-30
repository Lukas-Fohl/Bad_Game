using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display_highscore : MonoBehaviour
{
    public Text texting;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+PlayerPrefs.GetInt("coin count"));
        }catch
        {

        }
        int i = PlayerPrefs.GetInt("highscore");
        int j = PlayerPrefs.GetInt("coin count");
        int k = PlayerPrefs.GetInt("score");
        texting.text = "";
        texting.text = $"high score: \n {i} \n\n score: \n {j} \n\n Points: \n{k}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
