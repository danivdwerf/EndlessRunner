using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Achievement : MonoBehaviour 
{
    [SerializeField]private Image achievementObject;

    private AudioSource source;
    [SerializeField]private AudioClip oh_wow;

    private Animation anim;

    public static Achievement achievement;

	void Start () 
    {
        achievement = this;
        anim = achievementObject.GetComponent<Animation>(); 
        source = GetComponent<AudioSource>();
	}

    public void NewHighscore()
    {
        source.PlayOneShot(oh_wow);
        anim.Play();
    }
}
