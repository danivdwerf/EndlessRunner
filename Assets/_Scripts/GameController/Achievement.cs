using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Achievement : MonoBehaviour 
{
    private AudioSource source;
    private Animation anim;
    [SerializeField]private Image achievement_object;
    [SerializeField]private AudioClip oh_wow;

    [SerializeField]private Sprite highschore;
    [SerializeField]private Sprite first_jump;

    public static Achievement achievement;
    private Score score_script;

	void Start () 
    {
        achievement = this;
        anim = achievement_object.GetComponent<Animation>(); 
        source = GetComponent<AudioSource>();
        score_script = GetComponent<Score>();
	}

    public void NewHighscore()
    {
        source.PlayOneShot(oh_wow);
        achievement_object.sprite = highschore;
        anim.Play();
    }

    public void FirstJump()
    {
        source.PlayOneShot(oh_wow);
        achievement_object.sprite = first_jump;
        anim.Play();
    }
}
