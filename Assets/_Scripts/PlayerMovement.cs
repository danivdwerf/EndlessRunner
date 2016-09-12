using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody rigidBody;
    private float speed;
    private float side_speed;
    private float jumpheight;
    private bool isFalling;

	void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        speed = 8f; //make it 20!
        isFalling = true;
        jumpheight = 25f;
        side_speed = 0;
	}

	private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isFalling)
        {
            rigidBody.velocity = new Vector3(0f, jumpheight, 0f);
            isFalling = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            side_speed = -10000;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            side_speed = 10000;
        }
        else
        {
            side_speed = 0;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale = new Vector3(1, 0.2f, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")&&isFalling)
        {
            isFalling = false;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.transform.position + transform.forward.normalized * speed * Time.deltaTime);
        rigidBody.AddForce(rigidBody.transform.right * side_speed);
        rigidBody.AddForce(0,-5000,0);
    }
}
