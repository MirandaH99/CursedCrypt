using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobScript : MonoBehaviour {

    public float bobMove = 20f;
    public float bobSpeed = 1f;
    public float x = 10f;
    public float y = 10f;
    public float z = 10f;
    float bobdirection = 1f;    //val is always 1 or -1, 1 is up, -1 is down

    public bool X;
    public bool Y;
    public bool Z;

    Vector3 startPos;
    Transform trans;
    // Use this for initialization
    void Start () {
        trans = gameObject.transform;
        startPos = trans.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 location = trans.position;

        if (X)
        {
            location.x += (bobdirection * Time.deltaTime * bobSpeed);

            if (location.x <= startPos.x)
            {
                bobdirection = 1f;
                location.x = startPos.x;
            }


            if (location.x >= (startPos.x + bobMove))
            {
                bobdirection = -1f;
                location.x = (startPos.x + bobMove);
            }

        }

        if(Y)
        {
            location.y += (bobdirection * Time.deltaTime * bobSpeed);

            if (location.y <= startPos.y)
            {
                bobdirection = 1f;
                location.y = startPos.y;
            }


            if (location.y >= (startPos.y + bobMove))
            {
                bobdirection = -1f;
                location.y = (startPos.y + bobMove);
            }
        }

        if(Z)
        {
            location.z += (bobdirection * Time.deltaTime * bobSpeed);

            if (location.z <= startPos.z)
            {
                bobdirection = 1f;
                location.z = startPos.z;
            }


            if (location.z >= (startPos.z + bobMove))
            {
                bobdirection = -1f;
                location.z = (startPos.z + bobMove);
            }
        }


        trans.position = location;
    }

    private void OnTriggerEnter(Collider other)
    {
            other.transform.parent = gameObject.transform;    
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
