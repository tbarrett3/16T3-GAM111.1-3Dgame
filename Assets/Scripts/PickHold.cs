using UnityEngine;
using System.Collections;

public class PickHold : MonoBehaviour
{

    public float pointDistance = 3f;
    public float stabiliseFactor = 0.5f;
    public float correctionForce = 50f;
    public float throwForce = 40f;

    public bool Held = false;
    public Transform heldObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Held)
        {
            var targetPoint = Camera.main.transform.TransformPoint(Vector3.forward * pointDistance);

            heldObject.position = Vector3.Lerp(heldObject.position, targetPoint, Time.deltaTime * correctionForce);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!Held)
            {
                RaycastHit hit = new RaycastHit();
                var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.rigidbody != null)
                    {
                        heldObject = hit.transform;
                        heldObject.GetComponent<Rigidbody>().useGravity = false;
                        Held = true;
                    }
                }
            }
            else
            {
                heldObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward;
                Held = false;
                heldObject.GetComponent<Rigidbody>().useGravity = true;
            }
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
}
