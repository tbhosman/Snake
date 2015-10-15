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
    public GameObject newHighscoreUI;
    public InputField highscoreName;
    public Text countdownText;
    public Text scoreText;
    private int score;
    public string playerName;

    void Start()
    {
        pauseUI.SetActive(false);
        quitUI.SetActive(false);
        gameOverUI.SetActive(false);
        areYouSureUI.SetActive(false);
        newHighscoreUI.SetActive(false);
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
        score = GameObject.Find("Player head").GetComponent<PlayerController>().score;

        if (!PlayerPrefs.HasKey("NAME#1"))
        {
            for (int i = 1; i <= 10; i++)
            {
                PlayerPrefs.SetInt("SCORE#" + i, 3);
                PlayerPrefs.SetString("NAME#" + i, "Snake");
            }
        }

        if (score > PlayerPrefs.GetInt("SCORE#10"))
        {
            NewHighscore();
        }
        else
        {
            gameOverUI.SetActive(true);
        }
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

    public void toHighscore()
    {
        Application.LoadLevel("Highscore");
    }

    public void NewHighscore()
    {
        newHighscoreUI.SetActive(true);
        scoreText.text = "Your total score was " + score.ToString() + ".";
    }

    public void SetNewHighscore()
    {
        if (score > PlayerPrefs.GetInt("SCORE#1"))
        {
            PlayerPrefs.SetInt("SCORE#1", score);
            PlayerPrefs.SetString("NAME#1", highscoreName.text);

        }
        else if (score > PlayerPrefs.GetInt("SCORE#2"))
        {
            PlayerPrefs.SetInt("SCORE#2", score);
            PlayerPrefs.SetString("NAME#2", highscoreName.text);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#3"))
        {
            PlayerPrefs.SetInt("SCORE#3", score);
            PlayerPrefs.SetString("NAME#3", highscoreName.text);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#4"))
        {
            PlayerPrefs.SetInt("SCORE#4", score);
            PlayerPrefs.SetString("NAME#4", highscoreName.text);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#5"))
        {
            PlayerPrefs.SetInt("SCORE#5", score);
            PlayerPrefs.SetString("NAME#5", highscoreName.text);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#6"))
        {
            PlayerPrefs.SetInt("SCORE#6", score);
            PlayerPrefs.SetString("NAME#6", highscoreName.text);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#7"))
        {
            PlayerPrefs.SetInt("SCORE#7", score);
            PlayerPrefs.SetString("NAME#7", highscoreName.text);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#8"))
        {
            PlayerPrefs.SetInt("SCORE#8", score);
            PlayerPrefs.SetString("NAME#8", highscoreName.text);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#9"))
        {
            PlayerPrefs.SetInt("SCORE#9", score);
            PlayerPrefs.SetString("NAME#9", highscoreName.text);
        }
        else
        {
            PlayerPrefs.SetInt("SCORE#10", score);
            PlayerPrefs.SetString("NAME#10", highscoreName.text);
        }
    }
}
