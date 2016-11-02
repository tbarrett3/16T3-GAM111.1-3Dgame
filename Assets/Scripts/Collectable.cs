using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{

    private CollectableManager collectmanager;

    // Use this for initialization
    void Start()
    {
        collectmanager = FindObjectOfType<CollectableManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}