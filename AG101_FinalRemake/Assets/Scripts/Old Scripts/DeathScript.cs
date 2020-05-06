using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeathScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DEAD!");

        Movement player = other.gameObject.GetComponentInParent<Movement>();
        RunnerScript ghost = other.gameObject.GetComponent<RunnerScript>();

        if (player)
        {
            player.Reset();
        }
    }
}
