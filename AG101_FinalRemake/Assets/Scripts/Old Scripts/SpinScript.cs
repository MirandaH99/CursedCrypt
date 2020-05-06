using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour {

    public Vector3 cubeSpin= Vector3.zero;
    Transform trans;

	// Use this for initialization
	void Start () {

        trans = gameObject.transform;
        Debug.Log(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
        trans.Rotate(cubeSpin * Time.deltaTime);
	}
}
