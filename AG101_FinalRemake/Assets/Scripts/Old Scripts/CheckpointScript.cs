using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CheckpointScript : MonoBehaviour {
    public bool HasReachedAlready = false;

    public GameObject newGhostPos;

	// Use this for initialization
	void Start () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        Movement player = other.gameObject.GetComponentInParent<Movement>();

        if (player)
        {
            if (!HasReachedAlready)
            {

                HasReachedAlready = true; 
                Debug.Log("Checkpoint Saved!");
                player.startPosition = transform.position + new Vector3(0,2,1);

                RunnerScript ghost = GameObject.FindObjectOfType<RunnerScript>();
                if (ghost)
                {
                    ghost.startPosition = ghost.gameObject.transform.position;
                }
            }
        }
    }
}
