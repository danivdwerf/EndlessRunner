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
        if (PlayerPrefs.GetFloat("volume")==null)
        {
            PlayerPrefs.SetFloat("volume", 50);
        }
        else
        {
            audioSource.volume = PlayerPrefs.GetFloat("volume");
        }
	}

    public void PlayButtonSound()
    {
        audioSource.Play();
        audioSource.loop = false;
    }
}
