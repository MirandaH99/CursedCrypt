using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : MonoBehaviour
{

    public GameObject spawnPrefab;
    public GameObject spawnLocation;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Movement player = other.gameObject.GetComponentInParent<Movement>();

        if (player)
        {
            GameObject newObject = Instantiate(spawnPrefab, spawnLocation.transform.position,
                spawnLocation.transform.rotation);

            Counter();
        }
    }

    public void Counter()
    {
        int i = 0;
        while (i <= 500)
        {
            Debug.Log(i);
            i++;
        }
        if (i >= 500)
        {
            End();
        }
    }

    public void End()
    {
        Debug.Log("end");
        Application.Quit();
    }
}
