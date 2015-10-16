using UnityEngine;
using System.Collections;

public class GameOverSoundController : MonoBehaviour {

    private AudioSource gameOverSource;
    public AudioClip gameOverClip;

    // Use this for initialization
    void Start()
    {
        gameOverSource = GetComponent<AudioSource>();
    }

    public void playGameOverMusic()
    {
        gameOverSource.PlayOneShot(gameOverClip);
    }
}
