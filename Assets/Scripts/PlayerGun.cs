using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour {

    public string SwitchGravMsg = "SwitchGrav";
    public string LockPosMsg = "LockPos";

    public static bool useGun = true;

    public Animator GunAnim; //Set in editor

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(useGun == true)
        {
            
            if (Input.GetMouseButtonDown(0))
            {//Left Click
                SwitchGravShot();
            }

            if (Input.GetMouseButtonDown(1))
            {//Right Click
                LockPosShot();
            }
        }

    }
    
    public void SwitchGravShot()
    {
        Debug.Log("Grav Click");
        GunAnim.SetTrigger("RecoilNow");
        RaycastHit hit = new RaycastHit();
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                hit.collider.gameObject.SendMessage(SwitchGravMsg, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    
    public void LockPosShot()
    {
        Debug.Log("Lock Position Click");
        GunAnim.SetTrigger("RecoilNow");
        RaycastHit hit = new RaycastHit();
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                hit.collider.gameObject.SendMessage(LockPosMsg, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    //Controls what the gun does and what buttons control it
    
    //if left mouse clicked 
        //send raycast
        //turn off objects gravity in rigidbody
        //if clicked again
        //reverse gravity option
            //if on turn off/ vice versa
    //if right mouse is clicked
        //send raycast
        //lock into position make kinematic
        //if clicked again
        //unlock object
            //reverse the lock and unlock
}
