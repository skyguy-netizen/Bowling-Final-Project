using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody rb;
    public GameObject ball;
    public GameObject pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, pin9, pin10;

    // private GameObject[] gameObjects = { pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, pin9, pin10 };

    int score;
    public Text scoreText;
    int turn = 1;
    int frame = 1;
    int points = 0;
    private Vector3 pin1_pos, pin2_pos, pin3_pos, pin4_pos, pin5_pos, pin6_pos, pin7_pos, pin8_pos, pin9_pos, pin10_pos;
    int frame1_1 = 0;
    int frame1_2 = 0;
    int frame2_1 = 0;
    int frame2_2 = 0;
    int frame3_1 = 0;
    int frame3_2 = 0;
    private Quaternion rotation = Quaternion.Euler(-90, 0, 0);

    private bool waitBallReset = false;

    private int score_update_called = 0;

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
        if (pin1.activeSelf && pin1.transform.rotation != rotation)
        {
            points++;
            pin1.SetActive(false);
        }
        if (pin2.activeSelf && pin2.transform.rotation != rotation)
        {
            points++;
            pin2.SetActive(false);
        }
        if (pin3.activeSelf && pin3.transform.rotation != rotation)
        {
            points++;
            pin3.SetActive(false);
        }
        if (pin4.activeSelf && pin4.transform.rotation != rotation)
        {
            points++;
            pin4.SetActive(false);
        }
        if (pin5.activeSelf && pin5.transform.rotation != rotation)
        {
            points++;
            pin5.SetActive(false);
        }
        if (pin6.activeSelf && pin6.transform.rotation != rotation)
        {
            points++;
            pin6.SetActive(false);
        }
        if (pin7.activeSelf && pin7.transform.rotation != rotation)
        {
            points++;
            pin7.SetActive(false);
        }
        if (pin8.activeSelf && pin8.transform.rotation != rotation)
        {
            points++;
            pin8.SetActive(false);
        }
        if (pin9.activeSelf && pin9.transform.rotation != rotation)
        {
            points++;
            pin9.SetActive(false);
        }
        if (pin10.activeSelf && pin10.transform.rotation != rotation)
        {
            points++;
            pin10.SetActive(false);
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
            turn = 1;
            frame++;
            reset_game();
        }
        scoreText.text = "| " + frame1_1 + " " + frame1_2 + " | " + frame2_1 + " " + frame2_2 + " | " + frame3_1 + " " + frame3_2 + " | ";
        points = 0;
        score_update_called = 0;
        turn++;
        reset_ball();
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
            waitBallReset = false;
        }

        if (ball.transform.position.x < 2.24f)
        {
            waitBallReset = false;
        }

        if (ball.transform.position.x >= 2.24f && !waitBallReset)
        {
            Debug.Log("[CS135] Ball passed line");
            waitBallReset = true;
            score_update();
            // Debug.Log("[CS135] Object: " + transform.name);
        }

        // if (waitBallReset)
        // {
        //     if (score_update_called < 1)
        //     {
        //         score_update_called++;
        //         //score_update();
        //     }
        //     // Debug.Log("[CS135] score_update_called: " + score_update_called);

        // }
        
    }

    void reset_ball()
    {
        rb.isKinematic = true;
        ball.transform.position = new Vector3(-18.6690006f,6.19399977f,-0.103327632f);
        rb.isKinematic = false;
    }

    void reset_game()
    {
        reset_ball();

        //add timer
        pin1.SetActive(true);
        pin2.SetActive(true);
        pin3.SetActive(true);
        pin4.SetActive(true);
        pin5.SetActive(true);
        pin6.SetActive(true);
        pin7.SetActive(true);
        pin8.SetActive(true);
        pin9.SetActive(true);
        pin10.SetActive(true);


        pin1.transform.position = pin1_pos;
        pin1.transform.rotation = rotation;

        pin2.transform.position = pin2_pos;
        pin2.transform.rotation = rotation;

        pin3.transform.position = pin3_pos;
        pin3.transform.rotation = rotation;

        pin4.transform.position = pin4_pos;
        pin4.transform.rotation = rotation;

        pin5.transform.position = pin5_pos;
        pin5.transform.rotation = rotation;

        pin6.transform.position = pin6_pos;
        pin6.transform.rotation = rotation;

        pin7.transform.position = pin7_pos;
        pin7.transform.rotation = rotation;

        pin8.transform.position = pin8_pos;
        pin8.transform.rotation = rotation;

        pin9.transform.position = pin9_pos;
        pin9.transform.rotation = rotation;

        pin10.transform.position = pin10_pos;
        pin10.transform.rotation = rotation;

            
    }
}
