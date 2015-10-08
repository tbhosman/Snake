using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotation_speed;
    private int count;
    public Text GameOverText;
    public Text CountText;
    private GameObject[] Body;
    public GameObject Body_prefab;
    public GameObject start_block;

    private Rigidbody rb;

    void Start()
    {
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
            count++;
            SetCountText();
            AddBodyPart();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick-up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
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
        if (count == 0)
        {
            Body[count + 2] = Instantiate(Body_prefab);
            Body[count + 2].GetComponent<BodyController>().player = start_block; //Deze regel werkt niet        
        }
        else
        {
            Body[count + 2] = Instantiate(Body_prefab);
            Body[count + 2].GetComponent<BodyController>().player = Body[count + 1]; //Deze regel werkt ook niet
        }
    }
}