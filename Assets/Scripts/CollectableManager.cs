using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour {

    public List<GameObject> Collectables = new List<GameObject>();
    public Text CollectText;
    private int currentCollect = 0;

	// Use this for initialization
	void Start () {
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
        CollectText.text = "Int / " + Collectables.Capacity;
    }

}
