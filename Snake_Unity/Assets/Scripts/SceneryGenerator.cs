using UnityEngine;
using System.Collections;

public class SceneryGenerator : MonoBehaviour {

    public float boat_chance;
    public GameObject boatPrefab;
    public float rock_chance;
    public GameObject[] rockPrefab;
    public GameObject[] rockPrefabSphere;
    public float seaweed_chance;
    public GameObject[] seaweedPrefab;
    private int index;
    private int index2;
    private GameObject seaweed1;
    private GameObject seaweed2;
    private GameObject seaweed3;
    private GameObject seaweed4;
    private GameObject seaweed5;

    private float random_number;

	void Start () {
        for (float x = -60; x <= 60; x = x + 5)
        {
            for (float z = -60; z <= 60; z = z + 5)
            {
                random_number = Random.Range(0.0f, 1.0f);
                if ((random_number < boat_chance) && (Mathf.Abs(z)>10 || Mathf.Abs(x) > 20) && Mathf.Abs(z)<45 && Mathf.Abs(x)<45)
                {
                    GameObject boat = (GameObject) Instantiate(boatPrefab, transform.TransformPoint(new Vector3(x, -0.5f, z) + LocationVariety()), BoatRotationVariety());
                    boat.transform.parent = GameObject.Find("Scenery").transform;
                }
                else if ((random_number < (boat_chance+rock_chance)) && (Mathf.Abs(z) > 10 || Mathf.Abs(x) > 20) && Mathf.Abs(z) < 45 && Mathf.Abs(x) < 45)
                {
                    index = Random.Range(0, rockPrefab.Length);
                    GameObject rock = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(x, 0, z) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
                    GameObject rock_sphere = (GameObject)Instantiate(rockPrefabSphere[index], rock.transform.position,rock.transform.rotation);
                    rock.transform.parent = GameObject.Find("Scenery").transform;
                    rock_sphere.transform.parent = rock.transform;
                }
                else if ((random_number < (boat_chance + rock_chance + seaweed_chance)) && (random_number>(boat_chance+ rock_chance)))
                {
                    index2 = Random.Range(0, seaweedPrefab.Length);
                    if (index2 == 1)
                    {
                        seaweed1 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
                        seaweed2 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
                        seaweed3 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
                        seaweed4 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
                        seaweed5 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));

                    }
                    else
                    {
                        seaweed1 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(29, Random.Range(0, 360), 190)));
                        seaweed2 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(29, Random.Range(0, 360), 190)));
                        seaweed3 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(29, Random.Range(0, 360), 190)));
                        seaweed4 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(29, Random.Range(0, 360), 190)));
                        seaweed5 = (GameObject)Instantiate(seaweedPrefab[index2], transform.InverseTransformPoint(new Vector3(x, 0, z) + SeaweedLocationVariety()), Quaternion.Euler(new Vector3(29, Random.Range(0, 360), 190)));

                    }

                    seaweed1.transform.parent = GameObject.Find("Scenery").transform;
                    seaweed2.transform.parent = GameObject.Find("Scenery").transform;
                    seaweed3.transform.parent = GameObject.Find("Scenery").transform;
                    seaweed4.transform.parent = GameObject.Find("Scenery").transform;
                    seaweed5.transform.parent = GameObject.Find("Scenery").transform;
                }
            }
        }

        for (float x = -70; x <= 70; x = x + 3)
        {
            index = Random.Range(0, rockPrefab.Length);
            GameObject rock1 = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(x, 0, 70) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            GameObject rock2 = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(x, 0, -70) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            GameObject rock_sphere1 = (GameObject)Instantiate(rockPrefabSphere[index], rock1.transform.position, rock1.transform.rotation);
            GameObject rock_sphere2 = (GameObject)Instantiate(rockPrefabSphere[index], rock2.transform.position, rock2.transform.rotation);
            rock1.transform.parent = GameObject.Find("Scenery").transform;
            rock2.transform.parent = GameObject.Find("Scenery").transform;
            rock_sphere1.transform.parent = rock1.transform;
            rock_sphere2.transform.parent = rock2.transform;
        }

        for (float z = -70; z <= 70; z = z + 3)
        {
            index = Random.Range(0, rockPrefab.Length);
            GameObject rock1 = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(70, 0, z) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            GameObject rock2 = (GameObject)Instantiate(rockPrefab[index], transform.TransformPoint(new Vector3(-70, 0, z) + LocationVariety()), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
            GameObject rock_sphere1 = (GameObject)Instantiate(rockPrefabSphere[index], rock1.transform.position, rock1.transform.rotation);
            GameObject rock_sphere2 = (GameObject)Instantiate(rockPrefabSphere[index], rock2.transform.position, rock2.transform.rotation);
            rock1.transform.parent = GameObject.Find("Scenery").transform;
            rock2.transform.parent = GameObject.Find("Scenery").transform;
            rock_sphere1.transform.parent = rock1.transform;
            rock_sphere2.transform.parent = rock2.transform;
        }
    }

    private Vector3 LocationVariety()
    {
        return new Vector3(Random.Range(0, 1), 0, Random.Range(0, 1));
    }

    private Vector3 SeaweedLocationVariety()
    {
        return new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
    }

    private Quaternion BoatRotationVariety()
    {
        return Quaternion.Euler(new Vector3(Random.Range(-30,30),Random.Range(0,360), Random.Range(-30, 30)));
    }

}
