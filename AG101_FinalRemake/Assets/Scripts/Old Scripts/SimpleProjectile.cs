using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SimpleProjectile : MonoBehaviour {

    public float moveSpeed = 20f;
    public float lifetime = 15f;

    Rigidbody rb;

    // Use this for initialization
    void Start () {

        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = moveSpeed * gameObject.transform.forward;
        Destroy(gameObject, lifetime);
    }
	
	private void OnTriggerEnter(Collider other)
    {
        Movement player = other.gameObject.GetComponentInParent<Movement>();

        if(player)
        {
            player.Reset();
        }

        Destroy(gameObject);
    }
}
