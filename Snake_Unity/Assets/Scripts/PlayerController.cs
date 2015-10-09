using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotation_speed;
    private int count;
    public Text GameOverText;
    public Text CountText;
    private List<GameObject> Body;
    public GameObject Body_prefab;
    public GameObject start_block;
    public GameObject snake;

    private Rigidbody rb;

    void Start()
    {
        Body = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);
        GameOverText.text = "";
        count = 3;
        SetCountText();
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

        //Debug for adding body parts
        if (Input.GetKeyDown("space"))
        {
            AddBodyPart();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick-up"))
        {
            other.gameObject.SetActive(false);
            AddBodyPart();
        }
        else
        {
            GameOverText.text = "Game Over!";
            //add particle effect, background and restart-button
        }
    }

    void SetCountText()
    {
            CountText.text = "Length: " + count.ToString();
    }

    void AddBodyPart()
    {
        if (count == 3) //For first block that is added
        {
            GameObject body = Instantiate(Body_prefab);
            body.GetComponent<BodyController>().player = start_block;
            body.transform.parent = snake.transform;
            Body.Add(body);
        }
        else //For every next block that is added
        {
            GameObject body = Instantiate(Body_prefab);
            body.GetComponent<BodyController>().player = Body[count-4];
            body.transform.parent = snake.transform;
            Body.Add(body);
        }
        count++;
        SetCountText();
    }
}