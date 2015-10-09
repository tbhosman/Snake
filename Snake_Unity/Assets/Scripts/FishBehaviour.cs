using UnityEngine;
using System.Collections;

public class FishBehaviour : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

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
        rb.velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            transform.rotation = Quaternion.AngleAxis(Random.Range(-180.0F, 180.0F), Vector3.up);
        }
    }
}

// Set walls to be collider and trigger AND to be a normal collider, with a kinematic rigid body!
