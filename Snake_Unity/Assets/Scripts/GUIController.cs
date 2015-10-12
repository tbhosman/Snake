using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

    bool paused = false;
    public GameObject pauseUI;

    void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
             if (paused)
            {
                Time.timeScale = 0;
                pauseUI.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseUI.SetActive(false);
            }
        }

        if (paused)
        {
            
        }
    }
}
