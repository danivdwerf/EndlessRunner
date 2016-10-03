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

    public static PlayerMovement playerMovement;

    private PlayerAudio playerAudio;
    [SerializeField] private AudioClip running; 
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip slide;

	void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        playerAudio = GameObject.FindObjectOfType<PlayerAudio>();
        dead = false;
        playerMovement = this;

        isFalling = false;

        speed = 20f;
        jumpHeight = 25f;
        sideSpeed = 0;

        playerAudio.PlayAudio(running, true);
	}

    public bool Death
    {
        get
        { 
            return dead;
        }
        set
        { 
            dead = value;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.transform.position + transform.forward.normalized * speed * Time.deltaTime);
        rigidBody.AddForce(rigidBody.transform.right * sideSpeed);
        rigidBody.AddForce(0,-4000,0);
    }

    public void Jump()
    {
        if (!isFalling)
        {
            rigidBody.velocity = new Vector3(0f, jumpHeight, 0f);
            playerAudio.PlayAudio(jump, false);
            isFalling = true;
        }
    }

    public void SideWays(float value)
    {
        sideSpeed = value;
    }

    public void Slide()
    {
        transform.localScale = new Vector3(1, 0.2f, 1);
        if (!isFalling&&!dead)
        {
            playerAudio.PlayAudio(slide, true);

        }
    }

    public void Run()
    {
        transform.localScale = new Vector3(1, 1, 1);
        if (!isFalling&&!dead)
        {
            playerAudio.PlayAudio(running, true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Tags.ground) && isFalling && !dead)
        {
            isFalling = false;
            playerAudio.PlayAudio(running, true);
        }
    }
}
