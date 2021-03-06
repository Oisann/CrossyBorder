﻿using UnityEngine;
using System.Collections;

public class CustomAudioSource : MonoBehaviour
{
	
	public enum AudioTypes
	{
		Music,
		Sound

	}

	public AudioTypes audioType;
	public AudioClip clip;
	public bool loop = false;
	public bool playOnWake = false;

	public AudioSource source;
	private string[] typeText = { "musicVolume", "soundVolume" };
	private string currentType;
	private bool playAfter;

	float timer;

	void Start ()
	{
		source = gameObject.AddComponent<AudioSource> ();
		source.clip = clip;
		source.loop = loop;
		source.playOnAwake = playOnWake;
		currentType = audioType == AudioTypes.Music ? typeText [0] : typeText [1];
		source.volume = PlayerPrefs.GetFloat (currentType);
		if (playOnWake)
			source.Play ();
	}

	void Update ()
	{
		if (source.volume != PlayerPrefs.GetFloat (currentType))
			source.volume = PlayerPrefs.GetFloat (currentType);


	}

	public void setLoop (bool _loop)
	{
		source.loop = _loop;
	}

	public void PlayOnce ()
	{
		source.PlayOneShot (clip);
	}

	public bool isPlaying ()
	{
		return source.isPlaying;
	}

	public void Play ()
	{
		source.Play ();
	}

	public void Play (AudioClip _clip)
	{
		
		source.PlayOneShot (_clip);
	}

    public void Stop() {
        source.Stop();
    }

	public AudioClip setClip (AudioClip clip)
	{
		source.clip = clip;
		return clip;
	}
}
