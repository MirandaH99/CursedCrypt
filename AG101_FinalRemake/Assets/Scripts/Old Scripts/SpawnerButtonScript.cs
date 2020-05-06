using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerButtonScript : MonoBehaviour {

    GameObject newobj;
    public GameObject spawnPrefab;
    public GameObject spawnLocation;

    bool used = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        SimpleProjectile sp = other.gameObject.GetComponent<SimpleProjectile>();
        BulletProjectile bp = other.gameObject.GetComponent<BulletProjectile>();
        if (used==false)
        {
            if (sp || bp)
            {
                Debug.Log("BUTTON HIT!");

                newobj = Instantiate(spawnPrefab, spawnLocation.transform.position,
                                spawnLocation.transform.rotation);
            }
            used = true;
        }

    }
}
