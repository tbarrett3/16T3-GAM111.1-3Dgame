using UnityEngine;
using System.Collections;

public class PickHold : MonoBehaviour
{

    public float pointDistance = 2.1f;
    public float correctionForce = 80f;
    public float throwForce = 1.5f;
    public float grabDistance = 5f;

    public static bool Held = false;
    public static Transform heldObject;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Held)
        {
            holdObject();
        }
        //has E been pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!Held) //make sure nothing is held
            {
                grabObject();
            }
            else
            {
                dropObject();
            }
        }
    }

    void holdObject()
    {
        Vector3 targetPoint = Camera.main.transform.TransformPoint(Vector3.forward * pointDistance);
        targetPoint += Camera.main.transform.forward * pointDistance;

        Vector3 force = targetPoint - heldObject.transform.position;

        heldObject.GetComponent<Rigidbody>().velocity = force.normalized * heldObject.GetComponent<Rigidbody>().velocity.magnitude;
        heldObject.GetComponent<Rigidbody>().AddForce(force * correctionForce);

        heldObject.GetComponent<Rigidbody>().velocity *= Mathf.Min(1f, force.magnitude / 2);
    }

    void grabObject()
    {
        RaycastHit hit = new RaycastHit();
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
            {//check distance between
                float distance = Vector3.Distance(this.transform.position, hit.transform.position);
                Debug.Log(distance);
                if (distance <= grabDistance)
                {
                    PlayerGun.useGun = false;
                    heldObject = hit.transform;
                    heldObject.GetComponent<Rigidbody>().isKinematic = false;
                    heldObject.GetComponent<Rigidbody>().useGravity = false;
                    heldObject.GetComponent<Rigidbody>().freezeRotation = true;
                    Held = true;
                }
            }
        }
    }

    void dropObject()
    {
        PlayerGun.useGun = true;
        heldObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * throwForce;
        Held = false;
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.GetComponent<Rigidbody>().freezeRotation = false;
    }

    //if E button is clicked
    //send raycast infront of player
    //if object hit is marked as carryable 
    //and if in range
    //move object to player hands (empty gameobject)
    //make child

    //if E is pressed again release object 
    //release child


    //This one https://forum.unity3d.com/threads/half-life-2-object-grabber.79352/
    //https://www.youtube.com/watch?v=runW-mf1UH0

}
