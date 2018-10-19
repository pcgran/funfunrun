using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocity;
    public float speed = 2f;
    public Vector3 startPosition;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private bool isWalkingRight;

    

    //Inventory
    public bool hasCassette;
    public bool hasCape;

    public bool cassetteDelivered;
    public bool capeDelivered;

    // Use this for initialization
    void Start () {
        startPosition = this.transform.position;
        velocity = 0f;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isWalkingRight = true;
        hasCassette = false;
        hasCape = false;
        cassetteDelivered = false;
        capeDelivered = false;
    }
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("velocity", velocity);
	}

    void FixedUpdate()
    {
        /*float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rigidbody2D.AddForce(Vector2.right * speed * h);
        rigidbody2D.AddForce(Vector2.up * speed * v);
        float limitedSpeed = Mathf.Clamp(rigidbody2D.velocity.x, -maxSpeed, maxSpeed);
        rigidbody2D.velocity = new Vector2(limitedSpeed, rigidbody2D.velocity.y);

        Debug.Log(rigidbody2D.velocity.x);*/

        animator.enabled = true;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(isWalkingRight)
            {
                rigidbody2D.transform.rotation *= Quaternion.Euler(0, 180f, 0);
                isWalkingRight = false;
            }
            rigidbody2D.transform.position += Vector3.left * speed * Time.deltaTime;
            velocity = 0.2f;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (!isWalkingRight)
            {
                rigidbody2D.transform.rotation *= Quaternion.Euler(0, -180f, 0);
                isWalkingRight = true;
            }
            rigidbody2D.transform.position += Vector3.right * speed * Time.deltaTime;
            velocity = 0.2f;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidbody2D.transform.position += Vector3.up * speed * Time.deltaTime;
            velocity = 0.2f;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigidbody2D.transform.position += Vector3.down * speed * Time.deltaTime;
            velocity = 0.2f;
        }
        if (Input.anyKey == false)
        {
            velocity = 0f;
            //animator.enabled = false;
        }
    }
}
