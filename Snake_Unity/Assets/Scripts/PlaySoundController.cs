using UnityEngine;
using System.Collections;

public class PlaySoundController : MonoBehaviour {

    private AudioSource playSource;
    public AudioClip playClip;

    // Use this for initialization
    void Start()
    {
        playSource = GetComponent<AudioSource>();
    }

    public void playPlayMusic()
    {
        playSource.PlayOneShot(playClip);
    }

    public void stopPlayMusic()
    {
        playSource.Stop();
    }
}
