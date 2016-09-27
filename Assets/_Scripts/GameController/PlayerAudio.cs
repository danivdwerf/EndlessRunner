using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour 
{
    [HideInInspector] public AudioSource source;

	private void Start () 
    {
        source = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<AudioSource>();
	}

    public void PlayAudio(AudioClip newClip, bool loop)
    {
        if (source != null)
        {
            if (source.clip != newClip)
            {
                source.Stop();
                source.clip = newClip;
                source.loop = loop;
                source.Play();
            }
        }
    }
}
