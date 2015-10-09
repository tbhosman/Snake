using UnityEngine;
using System.Collections;

public class FishSpawn : MonoBehaviour
{
    public GameObject Item;
    private GameObject[] respawns;

    // Use this for initialization
    void Start()
    {
        Vector3 RandomLocation = new Vector3(Random.Range(-50.0F, 50.0F), 1F, Random.Range(-50.0F, 50.0F));
        Instantiate(Item, RandomLocation, Quaternion.AngleAxis(Random.Range(-180.0F, 180.0F), Vector3.up));
    }

    // Update is called once per frame
    void Update()
    {
        respawns = GameObject.FindGameObjectsWithTag("Fish");
        if (respawns == null)
        {
            Vector3 RandomLocation = new Vector3(Random.Range(-50.0F, 50.0F), 1F, Random.Range(-50.0F, 50.0F));
            Instantiate(Item, RandomLocation, Quaternion.AngleAxis(Random.Range(-180.0F, 180.0F), Vector3.up));
        }
    }
}
