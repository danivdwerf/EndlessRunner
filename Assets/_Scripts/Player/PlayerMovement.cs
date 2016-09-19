using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody rigidBody;
    private float speed;
    private float sideSpeed;
    private float jumpHeight;

    private bool isFalling;
    private bool dead;


    private PlayerAudio playerAudio;
    [SerializeField] private AudioClip running; 
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip slide;
    [SerializeField] private AudioClip hurt;

    public static PlayerMovement player_movement;

	void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        playerAudio = GameObject.FindObjectOfType<PlayerAudio>();
        player_movement = this; 
        dead = false;

        isFalling = false;

        speed = 20f;
        jumpHeight = 25f;
        sideSpeed = 0;

        playerAudio.PlayAudio(running, true);
	}

	private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isFalling)
        {
            rigidBody.velocity = new Vector3(0f, jumpHeight, 0f);
            playerAudio.PlayAudio(jump, false);
            isFalling = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            sideSpeed = -10000;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            sideSpeed = 10000;
        }
        else
        {
            sideSpeed = 0;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale = new Vector3(1, 0.2f, 1);
            if (!isFalling&&!dead)
            {
                playerAudio.PlayAudio(slide, true);

            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (!isFalling&&!dead)
            {
                playerAudio.PlayAudio(running, true);
            }
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")&&isFalling&&!dead)
        {
            isFalling = false;
            playerAudio.PlayAudio(running, true);
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.transform.position + transform.forward.normalized * speed * Time.deltaTime);
        rigidBody.AddForce(rigidBody.transform.right * sideSpeed);
        rigidBody.AddForce(0,-4000,0);
    }
}
