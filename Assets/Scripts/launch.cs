using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Collider bc;
    public Collider pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, pin9, pin10;

    // private GameObject[] gameObjects = { pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, pin9, pin10 };

    public Text scoreText;
    int turn = 1;
    int frame = 1;
    int points = 0;
    private Vector3 pin1_pos, pin2_pos, pin3_pos, pin4_pos, pin5_pos, pin6_pos, pin7_pos, pin8_pos, pin9_pos, pin10_pos;


    int total_round_score = 0;
    
    int frame1_1 = 0;
    int frame1_2 = 0;
    int frame2_1 = 0;
    int frame2_2 = 0;
    int frame3_1 = 0;
    int frame3_2 = 0;
    private Quaternion rotation = Quaternion.Euler(-90, 0, 0);

    // private bool waitBallReset = false;

    // private int score_update_called = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bowling_ball")
        {
            Debug.Log("[CS135] Ball triggered collision");
            other.attachedRigidbody.isKinematic = true;
            other.gameObject.transform.position = new Vector3(-14.9029999f, 0.98299998f, 1.18499947f);
            other.attachedRigidbody.isKinematic = false;
            score_update();
            Debug.Log("[CS135] Score updated from collision");
        }
    }

    void Start()
    {
        pin1_pos = pin1.transform.position;
        pin2_pos = pin2.transform.position;
        pin3_pos = pin3.transform.position;
        pin4_pos = pin4.transform.position;
        pin5_pos = pin5.transform.position;
        pin6_pos = pin6.transform.position;
        pin7_pos = pin7.transform.position;
        pin8_pos = pin8.transform.position;
        pin9_pos = pin9.transform.position;
        pin10_pos = pin10.transform.position;
        scoreText.text = "| " + frame1_1 + " " + frame1_2 + " | " + frame2_1 + " " + frame2_2 + " | " + frame3_1 + " " + frame3_2 + " | ";
    }

    // Update is called once per frame

    void score_update()
    {
        if (pin1.gameObject.activeSelf && pin1.transform.rotation != rotation)
        {
            points++;
            pin1.gameObject.SetActive(false);
        }
        if (pin2.gameObject.activeSelf && pin2.transform.rotation != rotation)
        {
            points++;
            pin2.gameObject.SetActive(false);
        }
        if (pin3.gameObject.activeSelf && pin3.transform.rotation != rotation)
        {
            points++;
            pin3.gameObject.SetActive(false);
        }
        if (pin4.gameObject.activeSelf && pin4.transform.rotation != rotation)
        {
            points++;
            pin4.gameObject.SetActive(false);
        }
        if (pin5.gameObject.activeSelf && pin5.transform.rotation != rotation)
        {
            points++;
            pin5.gameObject.SetActive(false);
        }
        if (pin6.gameObject.activeSelf && pin6.transform.rotation != rotation)
        {
            points++;
            pin6.gameObject.SetActive(false);
        }
        if (pin7.gameObject.activeSelf && pin7.transform.rotation != rotation)
        {
            points++;
            pin7.gameObject.SetActive(false);
        }
        if (pin8.gameObject.activeSelf && pin8.transform.rotation != rotation)
        {
            points++;
            pin8.gameObject.SetActive(false);
        }
        if (pin9.gameObject.activeSelf && pin9.transform.rotation != rotation)
        {
            points++;
            pin9.gameObject.SetActive(false);
        }
        if (pin10.gameObject.activeSelf && pin10.transform.rotation != rotation)
        {
            points++;
            pin10.gameObject.SetActive(false);
        }

        if (turn == 1)
        {
            if (frame == 1)
            {
                frame1_1 = points;
            }
            else if (frame == 2)
            {
                frame2_1 = points;
            }
            else if (frame == 3)
            {
                frame3_1 = points;
            }

            if (points == 10)
            {
                turn = 2;
            }

        }
        else if (turn == 2)
        {
            if (frame == 1)
            {
                frame1_2 = points;
            }
            else if (frame == 2)
            {
                frame2_2 = points;
            }
            else if (frame == 3)
            {
                frame3_2 = points;
            }
        }

        // Debug.Log("[CS135] Ball position before: " + ball.transform.position);
        Debug.Log("[CS135] score update function called");
        // Debug.Log("[CS135] Ball position after: " + (ball.transform.position.x >= 2.24f));
        Debug.Log("[CS135] Turn: " + turn);
        Debug.Log("[CS135] Frame: " + frame);

        if (frame >= 4)
        {
            frame = 1;
            scoreText.text = "game over";
        }
        if (turn >= 2)
        {
            turn = 0;
            frame++;
            reset_game();
        }
        scoreText.text = "| " + frame1_1 + " " + frame1_2 + " | " + frame2_1 + " " + frame2_2 + " | " + frame3_1 + " " + frame3_2 + " | ";
        points = 0;
        // score_update_called = 0;
        turn++;
        // reset_ball();
        Debug.Log("[CS135] ball reset");
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            reset_game();
            frame = 1;
            turn = 1;
            points = 0;
            frame1_1 = 0;
            frame1_2 = 0;
            frame2_1 = 0;
            frame2_2 = 0;
            frame3_1 = 0;
            frame3_2 = 0;
            scoreText.text = "| " + frame1_1 + " " + frame1_2 + " | " + frame2_1 + " " + frame2_2 + " | " + frame3_1 + " " + frame3_2 + " | ";
        }
        
    }

    void reset_ball()
    {
        bc.attachedRigidbody.isKinematic = true;
        bc.gameObject.transform.position = new Vector3(-14.9029999f, 0.98299998f, 1.18499947f);
        bc.attachedRigidbody.isKinematic = false;
        
    }

    void reset_game()
    {
        reset_ball();

        //add timer
        pin1.gameObject.SetActive(true);
        pin2.gameObject.SetActive(true);
        pin3.gameObject.SetActive(true);
        pin4.gameObject.SetActive(true);
        pin5.gameObject.SetActive(true);
        pin6.gameObject.SetActive(true);
        pin7.gameObject.SetActive(true);
        pin8.gameObject.SetActive(true);
        pin9.gameObject.SetActive(true);
        pin10.gameObject.SetActive(true);


        pin1.attachedRigidbody.isKinematic = true;
        pin1.gameObject.transform.position = pin1_pos;
        pin1.gameObject.transform.rotation = rotation;


        pin2.attachedRigidbody.isKinematic = true;
        pin2.transform.position = pin2_pos;
        pin2.transform.rotation = rotation;
        pin2.attachedRigidbody.isKinematic = false;

        pin3.attachedRigidbody.isKinematic = true;
        pin3.transform.position = pin3_pos;
        pin3.transform.rotation = rotation;
        pin3.attachedRigidbody.isKinematic = false;

        pin4.attachedRigidbody.isKinematic = true;
        pin4.transform.position = pin4_pos;
        pin4.transform.rotation = rotation;
        pin4.attachedRigidbody.isKinematic = false;

        pin5.attachedRigidbody.isKinematic = true;
        pin5.transform.position = pin5_pos;
        pin5.transform.rotation = rotation;
        pin5.attachedRigidbody.isKinematic = false;

        pin6.attachedRigidbody.isKinematic = true;
        pin6.transform.position = pin6_pos;
        pin6.transform.rotation = rotation;
        pin6.attachedRigidbody.isKinematic = false;

        pin7.attachedRigidbody.isKinematic = true;
        pin7.transform.position = pin7_pos;
        pin7.transform.rotation = rotation;
        pin7.attachedRigidbody.isKinematic = false;

        pin8.attachedRigidbody.isKinematic = true;
        pin8.transform.position = pin8_pos;
        pin8.transform.rotation = rotation;
        pin8.attachedRigidbody.isKinematic = false;

        pin9.attachedRigidbody.isKinematic = true;
        pin9.transform.position = pin9_pos;
        pin9.transform.rotation = rotation;
        pin9.attachedRigidbody.isKinematic = false;

        pin10.attachedRigidbody.isKinematic = true;
        pin10.transform.position = pin10_pos;
        pin10.transform.rotation = rotation;
        pin10.attachedRigidbody.isKinematic = false;
    }
}
