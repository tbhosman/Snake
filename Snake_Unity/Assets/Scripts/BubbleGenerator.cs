using UnityEngine;
using System.Collections;

public class BubbleGenerator : MonoBehaviour {

    public int max_x;
    public int min_x;
    public int max_z;
    public int min_z;
    public int bubbles;
    public GameObject bubble_object;
    public GameObject bubble_parent;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < bubbles; i++)
        {
            Vector3 rand_pos = new Vector3(Random.Range(min_x, max_x), 1, Random.Range(min_z, max_z));
            GameObject Bubble = (GameObject) Instantiate(bubble_object,rand_pos,Quaternion.Euler(new Vector3(-90,0,0))); //Randomly place bubble effect
            Bubble.transform.parent = bubble_parent.transform; //Add as child to 'Bubbles'
        }	
	}
}
