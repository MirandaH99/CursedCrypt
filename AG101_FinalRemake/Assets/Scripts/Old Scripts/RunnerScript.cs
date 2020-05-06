using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerScript : MonoBehaviour {

    public GameObject Player;
    public float MovementSpeed = 5f;
    public bool HasDynamicDirection =true;
    GameObject Target;
    Vector3 MoveDirection = Vector3.zero;
    public Vector3 startPosition = Vector3.zero;
    bool isMovingToTargetA = true;
    Transform trans;

    Quaternion rotQ;
    bool playerDead = false;

    // Use this for initialization
    void Start () {
        trans = gameObject.transform;
        rotQ = gameObject.transform.rotation;

        startPosition = trans.position;
        if (!Player)
        {
            Debug.Log("Bad Designer, no Target set!!!"); 
        }
        Target = Player;
        UpdateMoveDirection();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 Location = trans.position; 

        if(HasDynamicDirection)
        {
            UpdateMoveDirection();
        }

        Location += (MoveDirection * MovementSpeed * Time.deltaTime);

        trans.rotation = Quaternion.LookRotation(MoveDirection); 

        trans.position = Location; 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DEAD!");

        Movement player = other.gameObject.GetComponentInParent<Movement>();

        if (player)
        {
            player.Reset();
            // This will reset the ghost! 
        }
    }

    public void UpdateMoveDirection()
    {      
        MoveDirection = Target.transform.position - trans.position;
        MoveDirection = MoveDirection.normalized; 
    }

    public void Reset()
    {
        gameObject.transform.rotation = rotQ;
        gameObject.transform.position = startPosition;
        playerDead = false;
    }
}
