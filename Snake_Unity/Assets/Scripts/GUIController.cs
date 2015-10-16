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
    public Text inputText;
    string messageToSend;

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
        GameObject.Find("MenuSound").GetComponent<MenuSoundController>().playMenuMusic();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && Time.timeScale == 1)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverUI.activeSelf && !mainMenuUI.activeSelf && (countdownText.text == ""))
        {
            
            if(quitUI.activeSelf)
            {
                pauseUI.SetActive(true);
                quitUI.SetActive(false);
            }

            if (areYouSureUI.activeSelf)
            {
                ToMenu();
            }

            if (pauseUI.activeSelf)
            {
                ContinuePress();
            }
        }
    }

    public void ContinuePress()
    {
        StartCoroutine(getReady());
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
        GameObject.Find("playSound").GetComponent<PlaySoundController>().stopPlayMusic();
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
            //Add highscore sound here
        }
        else
        {
            gameOverUI.SetActive(true);
            GameObject.Find("GameOverSound").GetComponent<GameOverSoundController>().playGameOverMusic();
        }
    }

    public void StartGame()
    {
        GameObject.Find("MenuSound").GetComponent<MenuSoundController>().stopMenuMusic();
        gameOverUI.SetActive(false);
        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        quitUI.SetActive(false);
        newHighscoreUI.SetActive(false);
        areYouSureUI.SetActive(false);
        StartCoroutine(getReady());
        GameObject.Find("PlaySound").GetComponent<PlaySoundController>().playPlayMusic();
    }

    IEnumerator getReady()
    {
        countdownText.enabled = true;
        countdownText.text = "3";
        yield return StartCoroutine(WaitForRealSeconds(1.0f));

        countdownText.text = "2";
        yield return StartCoroutine(WaitForRealSeconds(1.0f));

        countdownText.text = "1";
        yield return StartCoroutine(WaitForRealSeconds(1.0f));

        countdownText.text = "GO!";
        yield return StartCoroutine(WaitForRealSeconds(1.0f));

        countdownText.text = "";

        Time.timeScale = 1;
        countdownText.enabled = false;
    }

    IEnumerator WaitForRealSeconds(float waitTime)
    {
        float endTime = Time.realtimeSinceStartup + waitTime;

        while (Time.realtimeSinceStartup < endTime)
        {
            yield return null;
        }
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
            ShiftHighscore(2);
            PlayerPrefs.SetInt("SCORE#1", score);
            PlayerPrefs.SetString("NAME#1", messageToSend);

        }
        else if (score > PlayerPrefs.GetInt("SCORE#2"))
        {
            ShiftHighscore(3);
            PlayerPrefs.SetInt("SCORE#2", score);
            PlayerPrefs.SetString("NAME#2", messageToSend);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#3"))
        {
            ShiftHighscore(4);
            PlayerPrefs.SetInt("SCORE#3", score);
            PlayerPrefs.SetString("NAME#3", messageToSend);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#4"))
        {
            ShiftHighscore(5);
            PlayerPrefs.SetInt("SCORE#4", score);
            PlayerPrefs.SetString("NAME#4", messageToSend);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#5"))
        {
            ShiftHighscore(6);
            PlayerPrefs.SetInt("SCORE#5", score);
            PlayerPrefs.SetString("NAME#5", messageToSend);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#6"))
        {
            ShiftHighscore(7);
            PlayerPrefs.SetInt("SCORE#6", score);
            PlayerPrefs.SetString("NAME#6", messageToSend);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#7"))
        {
            ShiftHighscore(8);
            PlayerPrefs.SetInt("SCORE#7", score);
            PlayerPrefs.SetString("NAME#7", messageToSend);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#8"))
        {
            ShiftHighscore(9);
            PlayerPrefs.SetInt("SCORE#8", score);
            PlayerPrefs.SetString("NAME#8", messageToSend);
        }
        else if (score > PlayerPrefs.GetInt("SCORE#9"))
        {
            ShiftHighscore(10);
            PlayerPrefs.SetInt("SCORE#9", score);
            PlayerPrefs.SetString("NAME#9", messageToSend);
        }
        else
        {
            PlayerPrefs.SetInt("SCORE#10", score);
            PlayerPrefs.SetString("NAME#10", messageToSend);
        }
    }

    public void RelayMessageInputField()
    {
        if (Input.GetButtonDown("Submit"))
        {
            messageToSend = inputText.text;
            SetNewHighscore();
            ToMenu();
        }
    }

    public void RelayMessageEnter()
    {
        messageToSend = inputText.text;
        SetNewHighscore();
        ToMenu();
    }

    public void ShiftHighscore(int start)
    {
        for (int i = 10; i>=start; i--)
        {
            PlayerPrefs.SetInt("SCORE#" + i, PlayerPrefs.GetInt("SCORE#" + (i - 1)));
            PlayerPrefs.SetString("NAME#" + i, PlayerPrefs.GetString("NAME#" + (i - 1)));
        }
    }
}
