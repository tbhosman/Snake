using UnityEngine;
using System.Collections;

public class MenuSoundController : MonoBehaviour {

    private AudioSource menuSource;
    public AudioClip menuClip;

	// Use this for initialization
	void Start () {
    }
	
	public void playMenuMusic()
    {
        menuSource = GetComponent<AudioSource>();
        menuSource.PlayOneShot(menuClip);
    }
    
    public void stopMenuMusic()
    {
        menuSource.Stop();
    }
}
