using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{

    bool paused = false;
    public GameObject pauseUI;
    public GameObject quitUI;
    public GameObject gameOverUI;
    public GameObject mainMenuUI;
    public GameObject areYouSureUI;
    public Text countdownText;

    void Start()
    {
        pauseUI.SetActive(false);
        quitUI.SetActive(false);
        gameOverUI.SetActive(false);
        areYouSureUI.SetActive(false);
        mainMenuUI.SetActive(true);
        countdownText.text = "";
        Time.timeScale = 0;
    }

    void Update()
    {
        //Debug for death
        if (Input.GetKeyDown(KeyCode.D))
            GameOver();

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverUI.activeSelf && !mainMenuUI.activeSelf)
        {
            if (!quitUI.activeSelf)
            {
                paused = !paused;
            }
            
            if(quitUI.activeSelf)
            {
                pauseUI.SetActive(true);
                quitUI.SetActive(false);
            }

            if (areYouSureUI.activeSelf)
            {
                ToMenu();
            }
            
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
    }

    public void ContinuePress()
    {
        paused = false;
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void QuitPress()
    {
        pauseUI.SetActive(false);
        quitUI.SetActive(true);
    }

    public void ToMenu()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ToDesktop()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(false);
        quitUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void StartGame()
    {
        gameOverUI.SetActive(false);
        mainMenuUI.SetActive(false);
        countdownText.text = "3";
        StartCoroutine(waitSomeTime());
        countdownText.text = "2";
        StartCoroutine(waitSomeTime());
        countdownText.text = "1";
        StartCoroutine(waitSomeTime());
        countdownText.text = "GO!";
        StartCoroutine(waitSomeTime());
        countdownText.text = "";
        Time.timeScale = 1;
    }

    IEnumerator waitSomeTime()
    {
        yield return new WaitForSeconds(2);
    }

    public void AreYouSure()
    {
        mainMenuUI.SetActive(false);
        areYouSureUI.SetActive(true);
    }

}
