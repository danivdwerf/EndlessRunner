using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody rigidBody;
    private float speed;
    private float side_speed;
    private float jumpheight;
    private bool isFalling;
    private bool dead;
    private AudioSource audio_source;
    [SerializeField] private AudioClip running; 
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip slide;
    [SerializeField] private AudioClip hurt;

    public static PlayerMovement player_movement;

	void Start () 
    {
        rigidBody = GetComponent<Rigidbody>();
        audio_source = GetComponent<AudioSource>();
        dead = false;
        player_movement = this; 
        speed = 20f; //make it 20!
        isFalling = true;
        jumpheight = 25f;
        side_speed = 0;
        audio_source.clip = running;
        audio_source.Play();
        audio_source.loop = true;
	}

	private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isFalling)
        {
            rigidBody.velocity = new Vector3(0f, jumpheight, 0f);
            audio_source.Stop();
            audio_source.clip = jump;
            audio_source.loop = false;
            audio_source.Play();
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
            if (audio_source.clip != slide&&!isFalling&&!dead)
            {
                audio_source.Stop();
                audio_source.clip = slide;
                audio_source.loop = true;
                audio_source.Play();
            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (audio_source.clip != running&&!isFalling&&!dead)
            {
                audio_source.Stop();
                audio_source.clip = running;
                audio_source.loop = true;
                audio_source.Play();
            }
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")&&isFalling&&!dead)
        {
            isFalling = false;
            audio_source.Stop();
            audio_source.clip = running;
            audio_source.loop = true;
            audio_source.Play();
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.transform.position + transform.forward.normalized * speed * Time.deltaTime);
        rigidBody.AddForce(rigidBody.transform.right * side_speed);
        rigidBody.AddForce(0,-4000,0);
    }

    public void Hurt()
    {
        dead = true;
        audio_source.Stop();
        audio_source.loop = false;
        audio_source.PlayOneShot(hurt);
    }
}
