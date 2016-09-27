using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Achievement : MonoBehaviour 
{
    [SerializeField]private Image achievementImage;

    private AudioSource source;
    [SerializeField]private AudioClip achievementSound;

    private Animation anim;

    public static Achievement achievement;

	void Start () 
    {
        achievement = this;
        anim = achievementImage.GetComponent<Animation>(); 
        source = GetComponent<AudioSource>();
	}

    public void NewHighscore()
    {
        source.PlayOneShot(achievementSound);
        anim.Play();
    }
}
