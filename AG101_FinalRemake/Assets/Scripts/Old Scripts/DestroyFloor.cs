using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloor : MonoBehaviour {

    public GameObject floorToDestroy;

    public GameObject spawnPrefab;
    public GameObject spawnLocation;

    private void OnTriggerEnter(Collider other)
    {
        Movement player = other.gameObject.GetComponentInParent<Movement>();

        if (player)
        {
            GameObject newObject = Instantiate(spawnPrefab, spawnLocation.transform.position,
                            spawnLocation.transform.rotation);
            Destroy(floorToDestroy);
        }
    }
}
