using UnityEngine;


//GameObject ball;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        launchBall();
    }

    void launchBall()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch)){
            // Debug.Log("[CS135 Lab2] Position before: " + CameraRig.transform.position);
            // transform.position = transform.position - CameraRig.transform.position + (new Vector3(0f, 0.675f, 0f));

            // Debug.Log("[CS135 Lab2] Position after: " + CameraRig.transform.position);
        }
    }
}
