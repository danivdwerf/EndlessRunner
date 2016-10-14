using UnityEngine;
using System.Collections;

public class ButtonSound : MonoBehaviour 
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;
	void Start () 
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickSound;
	}

    public void PlayButtonSound()
    {
        audioSource.Play();
        audioSource.loop = false;
    }
}
