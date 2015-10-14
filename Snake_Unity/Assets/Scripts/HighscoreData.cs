using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighscoreData : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    if (!PlayerPrefs.HasKey("NAME#"))
        {
            for (int i = 1; i <= 10; i++)
                {
                    PlayerPrefs.SetInt("SCORE#" + i, 3);
                    PlayerPrefs.SetString("NAME#" + i, "Snake");
                }
        }

        for (int i = 1; i <= 10; i++)
        {
            GameObject.Find("#" + i + " score").GetComponent<Text>().text = PlayerPrefs.GetInt("SCORE#" + i).ToString();
            GameObject.Find("#" + i + " name").GetComponent<Text>().text = i + "." + PlayerPrefs.GetString("NAME#" + i);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void BackToMenu()
    {
        Application.LoadLevel("Snake_Underwater");
    }
}
