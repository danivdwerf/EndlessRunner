using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour 
{
    [HideInInspector] public AudioSource audio_source;

	void Start () 
    {
        audio_source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
	}

    public void PlayAudio(AudioClip newClip, bool loop)
    {
        if (audio_source != null)
        {
            if (audio_source.clip != newClip)
            {
                audio_source.Stop();
                audio_source.clip = newClip;
                audio_source.loop = loop;
                audio_source.Play();
            }
        }
    }
}
