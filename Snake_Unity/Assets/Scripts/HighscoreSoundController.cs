using UnityEngine;
using System.Collections;

public class HighscoreSoundController : MonoBehaviour {

    private AudioSource highscoreSource;
    public AudioClip highscoreClip;

    // Use this for initialization
    void Start()
    {
        highscoreSource = GetComponent<AudioSource>();
    }

    public void playHighscoreMusic()
    {
        highscoreSource.PlayOneShot(highscoreClip);
    }
}
