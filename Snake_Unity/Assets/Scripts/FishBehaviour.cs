using UnityEngine;
using System.Collections;

public class FishBehaviour : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private int collision_count;
    public int collision_limit;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);
        transform.rotation = Quaternion.AngleAxis(Random.Range(-180.0F, 180.0F), Vector3.up);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
    }

    void OnTriggerStay(Collider other)
    {
        collision_count++;
        if (other.gameObject.CompareTag("Rock") || collision_count>collision_limit)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(transform.rotation.y-180, Vector3.up);
            //Random.Range(-180.0F, 180.0F)
        }

    }
}

// Set walls to be collider and trigger AND to be a normal collider, with a kinematic rigid body!
