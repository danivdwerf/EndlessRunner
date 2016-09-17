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
    private bool first_jump;
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

        first_jump = false;
        player_movement = this; 
        speed = 20f;
        isFalling = true;
        jumpheight = 25f;
        side_speed = 0;
        Play_Audio(running, true);
	}

	private void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!isFalling)
        {
            rigidBody.velocity = new Vector3(0f, jumpheight, 0f);
            Play_Audio(jump, false);
            isFalling = true;
            if (!first_jump)
            {
                first_jump = true;
                //Achievement.achievement.FirstJump();
            }
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
                Play_Audio(slide, true);
            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (audio_source.clip != running&&!isFalling&&!dead)
            {
                Play_Audio(running, true);
            }
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")&&isFalling&&!dead)
        {
            isFalling = false;
            Play_Audio(running, true);
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

    private void Play_Audio(AudioClip new_clip, bool loop)
    {
        audio_source.Stop();
        audio_source.clip = new_clip;
        audio_source.loop = loop;
        audio_source.Play();
    }
}
