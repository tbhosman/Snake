using UnityEngine;
using System.Collections;

public class MenuSoundController : MonoBehaviour {

    private AudioSource menuSource;
    public AudioClip menuClip;

	// Use this for initialization
	void Start () {
        menuSource = GetComponent<AudioSource>();
    }
	
	public void playMenuMusic()
    {
        menuSource.PlayOneShot(menuClip);
    }
    
    public void stopMenuMusic()
    {
        menuSource.Stop();
    }
}
