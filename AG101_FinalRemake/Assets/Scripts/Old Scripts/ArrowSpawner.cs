using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour {

    public GameObject spawnPrefab;
    public GameObject spawnLocation;
    public float lifetime = 15f;
    public float ShootRate = 60;
    int count = 0;
    GameObject newObject;
    Transform trans;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        count++;

        if(count == ShootRate)
        {
            newObject = Instantiate(spawnPrefab, spawnLocation.transform.position, spawnLocation.transform.rotation);
            count = 0;
        }      
    }
}
