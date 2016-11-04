using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour {

    public List<GameObject> Collectables = new List<GameObject>();
    public Text CollectText;
    private int currentCollect;

    void Awake ()
    {
        Collectables.Clear();
    }

	// Use this for initialization
	void Start () {
        currentCollect = 0;
        Collectables.AddRange(GameObject.FindGameObjectsWithTag("Collect"));
        UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Collected(GameObject go)
    {
        if (Collectables.Remove(go))
        {
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        CollectText.text = currentCollect + " / " + Collectables.Count;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.SetActive(false);
            currentCollect = currentCollect + 1;
            UpdateUI();
        }
    }
}
