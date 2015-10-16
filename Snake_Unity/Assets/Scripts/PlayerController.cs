using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotation_speed;
    public int count;
    public int score;
    public Text CountText;
    private List<GameObject> Body;
    public GameObject Body_prefab;
    public GameObject start_block;
    public GameObject snake;
    public GameObject canvas;

    public AudioClip bite1;
    public AudioClip bite2;
    public AudioClip bite3;
    private AudioSource bite_source;

    private Rigidbody rb;

    void Start()
    {
        Body = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);
        rb.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        count = 3;
        SetCountText();
        score = 0;
        bite_source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 rotate = new Vector3(0, moveHorizontal * rotation_speed, 0);   //Use input to rotate player
        rb.angularVelocity = rotate;

        rb.velocity = transform.TransformDirection(new Vector3(0,0,speed));    //Keep speed in local x-direction

    }

    void Update()
    {
        if ((Mathf.Abs(transform.position.x) > 80) || (Mathf.Abs(transform.position.z) > 80))
        {
            transform.position = new Vector3(0, 1, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
       {
            Destroy(other.gameObject);
            score = score + count;
            AddBodyPart();
            AddBodyPart();
            AddBodyPart();
            //randomly choose an eating sound
            int random_number = Random.Range(1, 4);
            if (random_number == 1)
            {
                bite_source.PlayOneShot(bite1, 0.4f);
            }
            else if (random_number == 2)
            {
                bite_source.PlayOneShot(bite2, 0.3f);
            }
            else if (random_number == 3)
            {
                bite_source.PlayOneShot(bite3, 0.3f);
            }
        }
        else if (!other.gameObject.CompareTag("StartBody") && !other.gameObject.CompareTag("Boundary"))
        {
            canvas.GetComponent<GUIController>().GameOver();
            //add particle effect
        }
    }

    void SetCountText()
    {
            CountText.text = "Score: " + score.ToString();
    }

    void AddBodyPart()
    {
        if (count == 3) //For first block that is added
        {
            GameObject body = (GameObject)Instantiate(Body_prefab, new Vector3(0, -5, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            body.GetComponent<BodyController>().player = start_block;
            body.transform.parent = snake.transform;
            Body.Add(body);
        }
        else //For every next block that is added
        {
            GameObject body = (GameObject)Instantiate(Body_prefab, new Vector3(0,-5,0),Quaternion.Euler(new Vector3(0,0,0)));
            body.GetComponent<BodyController>().player = Body[count-4];
            body.transform.parent = snake.transform;
            Body.Add(body);
        }
        count++;
        SetCountText();
    }
}