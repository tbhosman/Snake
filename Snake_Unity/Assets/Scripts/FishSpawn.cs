using UnityEngine;
using System.Collections;

public class FishSpawn : MonoBehaviour
{
    public GameObject Item;
    private GameObject[] respawns;
    public int fishAmount;

    // Use this for initialization
    void Start()
    {
        Vector3 RandomLocation = new Vector3(Random.Range(-50.0F, 50.0F), 1F, Random.Range(-50.0F, 50.0F));
        GameObject fish = (GameObject) Instantiate(Item, RandomLocation, Quaternion.AngleAxis(Random.Range(-180.0F, 180.0F), Vector3.up));
        fish.transform.parent = GameObject.Find("Fishes").transform;
    }

    // Update is called once per frame
    void Update()
    {
        respawns = GameObject.FindGameObjectsWithTag("Fish");
        if (respawns.Length < fishAmount)
        {
            Vector3 RandomLocation = new Vector3(Random.Range(-50.0F, 50.0F), 1F, Random.Range(-50.0F, 50.0F));
            GameObject fish = (GameObject) Instantiate(Item, RandomLocation, Quaternion.AngleAxis(Random.Range(-180.0F, 180.0F), Vector3.up));
            fish.transform.parent = GameObject.Find("Fishes").transform;
        }
    }
}
