using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Movement : Player {

    
    public float moveSpeed = 10f;
    public float rotSpeed = 180f;
    public float jumpSpeed = 10f;
    public float distToGround = 2f;
    public float DecentPercent = .3f; 
    Vector3 rotVect = Vector3.zero;
    public Vector3 startPosition = Vector3.zero;
    Quaternion rotQ;

    //public Animator animator;

    public Camera FPScam;
    public Camera TPScam;

    public GameObject spawnPrefab;
    public GameObject spawnLocation;

    public float horizontalAxis;
    public float verticalAxis;

    bool fire = false;
    bool jump = false;
    bool isGrounded = false;
    bool JumpPostPeak = false;
    bool fpsCam = true;
    float jumpcounter = 0;
    public float MaxJumpTime = 1.0f;

    //public AudioSource Jump;
    //public AudioSource Shoot;

    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();

        //animator = GetComponent<Animator>();

        //set start position

        startPosition = gameObject.transform.position;
        rotQ = gameObject.transform.rotation;

        FPScam.enabled = fpsCam;
        TPScam.enabled = !fpsCam;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        jump = Input.GetButton("Jump");

        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround);

        //Debug.Log(isGrounded);    

        if(Input.GetKey(KeyCode.E))
        {
            fpsCam = false;
            FPScam.enabled = fpsCam;
            TPScam.enabled = !fpsCam;
        }
        if (Input.GetKey(KeyCode.R))
        {
            fpsCam = true;
            FPScam.enabled = fpsCam;
            TPScam.enabled = !fpsCam;
        }

        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }

        if (!jump && !isGrounded) // Jump Key Released in air
        {
            JumpPostPeak = true;
        }

        if (jump && isGrounded) // Start of jump
        {
            //Jump.Play();
            JumpPostPeak = false; // Setup for first half of the jump
            jumpcounter = 0;
        }
        if (jump && !JumpPostPeak) // Up of the jump
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Acceleration);
            jumpcounter += Time.fixedDeltaTime; 
            if (jumpcounter > MaxJumpTime)
            {
                JumpPostPeak = true; 
            }
        }
        if (!isGrounded && JumpPostPeak) // Down of the jump
        {
            rb.AddForce(Vector3.down * jumpSpeed * DecentPercent, ForceMode.Acceleration);
        }

        fire = Input.GetButtonDown("Fire1");

        if (fire)
        {
            Fire();
        }
        
        Hortizontal(horizontalAxis);
        Vertical(verticalAxis);

        //animator.SetBool("isWalking", false);
    }

    public void Hortizontal(float value)
    {
        Vector3 newVelocity = Vector3.zero;
        if (Mathf.Abs(value) > .05)
        {
            rotVect.y = value * rotSpeed * Time.deltaTime;
            transform.Rotate(rotVect);    //TransformDirection(Vector3.right)

            //newVelocity = (value * moveSpeed * gameObject.transform.TransformDirection(Vector3.right));
        }
       // rb.velocity = newVelocity;
    }

    public void Vertical(float value)
    {

        Vector3 newVelocity = Vector3.zero;
        if (Mathf.Abs(value) > .05)
        {
           // animator.SetBool("isWalking", true);
            newVelocity = (value * moveSpeed * gameObject.transform.forward);
        }
        rb.velocity = newVelocity;
    }


    public void Fire()
    {
        ProjectileFire();
    }

    public void ProjectileFire()
    {
        //Shoot.Play();
        GameObject newObject = Instantiate(spawnPrefab, spawnLocation.transform.position,
                                    spawnLocation.transform.rotation);
    }

    public void Reset()
    {
        
        gameObject.transform.rotation = rotQ;
        gameObject.transform.position = startPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        RunnerScript ghost = GameObject.FindObjectOfType<RunnerScript>();
        if (ghost)
        {
            ghost.Reset();
        }
    }
}
