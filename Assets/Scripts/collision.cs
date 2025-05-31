using UnityEngine;

public class collision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("[CS135] Ball triggered collision");
        other.attachedRigidbody.isKinematic = true;
        other.gameObject.transform.position = new Vector3(-14.9029999f, 0.98299998f, 1.18499947f);
        other.attachedRigidbody.isKinematic = false;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Staying in Trigger: " + other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger Exited: " + other.gameObject.name);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
