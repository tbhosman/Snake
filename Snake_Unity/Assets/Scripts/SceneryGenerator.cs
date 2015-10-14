using UnityEngine;
using System.Collections;

public class SceneryGenerator : MonoBehaviour {

    //private float random_number;
    public float boat_chance;
    public GameObject boatPrefab;
    private float random_number;

	void Start () {
        for (float x = -45; x <= 45; x = x + 5)
        {
            for (float z = -45; z <= 45; z = z + 5)
            {
                random_number = Random.Range(0.0f, 1.0f);
                if ((random_number < boat_chance) && (Mathf.Abs(z)>10 || Mathf.Abs(x) > 20))
                {
                    GameObject boat = (GameObject) Instantiate(boatPrefab, transform.TransformPoint(new Vector3(x, -0.5f, z) + LocationVariety()), BoatRotationVariety());
                    boat.transform.parent = GameObject.Find("Scenery").transform;
                }
            }
        }
	}

    private Vector3 LocationVariety()
    {
        return new Vector3(Random.Range(0, 1), 0, Random.Range(0, 1));
    }

    private Quaternion BoatRotationVariety()
    {
        return Quaternion.Euler(new Vector3(Random.Range(-30,30),Random.Range(0,360), Random.Range(-30, 30)));
    }

}
