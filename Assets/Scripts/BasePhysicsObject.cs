using UnityEngine;
using System.Collections;

public class BasePhysicsObject : MonoBehaviour {

    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchGrav()
    {
        if (rb.useGravity == true)
        {
            rb.useGravity = false;
        }

        else
        {
            rb.useGravity = true;
        }
    }

    public void LockPos()
    {
        if (rb.isKinematic == true)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
}
