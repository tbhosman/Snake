using UnityEngine;
using System.Collections.Generic;

public class BodyController : MonoBehaviour {

    public int distance;

    private Vector3[] position_hist;

    public GameObject player;

    void Start () {
        position_hist = new Vector3[distance]; //generate a history array of length distance
        for (int i = 0; i < distance; i++)
        {
            position_hist[i] = player.transform.position; //Fill history with current position of block to follow
        }
    }
	
	void FixedUpdate () {
        transform.position = position_hist[0]; //Take oldest position in history as new position

        for (int i = 0; i < distance-1; i++)
        {
            position_hist[i] = position_hist[i + 1]; //Shift all positions by one
        }
        position_hist[distance-1] = player.transform.position; //Add new position

        transform.LookAt(player.transform.position); //Get proper rotation
    }
}
