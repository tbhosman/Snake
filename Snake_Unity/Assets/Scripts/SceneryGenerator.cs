using UnityEngine;
using System.Collections;

public class SceneryGenerator : MonoBehaviour {

    //private float random_number;
    public float boat_chance;
    public GameObject boatPrefab;
    public float rock_chance;
    public GameObject[] rockPrefab;
    int index;

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
                else if ((random_number < (boat_chance+rock_chance)) && (Mathf.Abs(z) > 10 || Mathf.Abs(x) > 20))
                {
                    index = Random.Range(0, rockPrefab.Length);
                    GameObject rock = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(x, 0, z) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
                    rock.transform.parent = GameObject.Find("Scenery").transform;
                }
            }
        }

        for (float x = -70; x <= 70; x = x + 2)
        {
            index = Random.Range(0, rockPrefab.Length);
            GameObject rock1 = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(x, 0, 70) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            GameObject rock2 = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(x, 0, -70) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            rock1.transform.parent = GameObject.Find("Scenery").transform;
            rock2.transform.parent = GameObject.Find("Scenery").transform;
        }

        for (float z = -70; z <= 70; z = z + 2)
        {
            index = Random.Range(0, rockPrefab.Length);
            GameObject rock1 = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(70, 0, z) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            GameObject rock2 = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(-70, 0, z) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            rock1.transform.parent = GameObject.Find("Scenery").transform;
            rock2.transform.parent = GameObject.Find("Scenery").transform;
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
