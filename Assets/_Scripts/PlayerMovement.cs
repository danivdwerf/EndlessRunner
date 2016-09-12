using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody rigidBody;
    private float speed;
    private float jumpheight;
    private bool isFalling;
	void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        speed = 8f;
        isFalling = true;
        jumpheight = 6f;
	}

	private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isFalling)
        {
            rigidBody.velocity = new Vector3(0f, jumpheight, 0f);
            isFalling = true;
        }
        Debug.Log(isFalling);
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
    }
}
