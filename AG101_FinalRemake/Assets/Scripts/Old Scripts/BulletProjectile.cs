using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    public float moveSpeed = 20f;
    public float lifetime = 15f;

    Rigidbody rb;
    // Use this for initialization
    void Start () {

        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = moveSpeed * -gameObject.transform.forward;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit something!");
        Destroy(gameObject);
    }
}
