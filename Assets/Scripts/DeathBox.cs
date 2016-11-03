using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            PlayerGun.useGun = false;
            if (PickHold.Held == true)
            {
                PickHold.Held = false;
                PickHold.heldObject.GetComponent<Rigidbody>().isKinematic = false;
                PickHold.heldObject.GetComponent<Rigidbody>().useGravity = true;
            }
            StartCoroutine (DeathTimer());
        }
    }

    IEnumerator DeathTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
} 
