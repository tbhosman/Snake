using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotation_speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 rotate = new Vector3(0, moveHorizontal * rotation_speed, 0);   //Use input to rotate player
        rb.angularVelocity = rotate;

        rb.velocity = transform.TransformDirection(new Vector3(speed,0,0));    //Keep speed in local x-direction

    }

    void Update()
    {
        if ((Mathf.Abs(transform.position.x) > 50) || (Mathf.Abs(transform.position.z) > 50))
        {
            transform.position = new Vector3(0, 1, 0);
        }
    }
}