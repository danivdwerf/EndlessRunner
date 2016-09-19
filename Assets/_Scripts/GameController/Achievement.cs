using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Achievement : MonoBehaviour 
{
    [SerializeField]private Image achievement_object;

    private AudioSource source;
    [SerializeField]private AudioClip oh_wow;

    private Animation anim;

    public static Achievement achievement;

	void Start () 
    {
        achievement = this;
        anim = achievement_object.GetComponent<Animation>(); 
        source = GetComponent<AudioSource>();
	}

    public void NewHighscore()
    {
        source.PlayOneShot(oh_wow);
        anim.Play();
    }
}
