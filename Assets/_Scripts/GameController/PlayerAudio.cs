using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAudio : MonoBehaviour 
{
    [HideInInspector] public AudioSource source;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Text volumeValue;
    public static PlayerAudio playerAudio;

	private void Start () 
    {
        source = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<AudioSource>();
        playerAudio = this;
        if (PlayerPrefs.HasKey("volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
        }
	}

    void Update()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        source.volume = volumeSlider.value = PlayerPrefs.GetFloat("volume");
        volumeValue.text = "Volume: "+Mathf.Round(volumeSlider.value * 100);
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
