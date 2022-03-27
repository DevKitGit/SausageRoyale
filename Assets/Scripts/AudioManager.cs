
using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class AudioManager
{
	public static void PlayOneShot(Audio audio, bool looping = false)
	{
		if (audio == null)
		{
			return;
		}
		
		GameObject gameObject = new GameObject("One shot audio");
		AudioSource audioSource = (AudioSource) gameObject.AddComponent(typeof (AudioSource));
		audioSource.clip = audio.Clip;
		audioSource.spatialBlend = 0;
		audioSource.volume = 1;
		audioSource.Play();
		Object.Destroy(gameObject, audio.Clip.length * (Time.timeScale < 0.00999999977648258 ? 0.01f : Time.timeScale));
	}
	
	public static void PlayOneShot(string name, bool looping = false)
	{
		var audio = GameManager.Assets.Audios.FirstOrDefault(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
		if (audio == null)
		{
			Debug.LogError($"Can't find audio clip \"{name}\"");
			return;
		}

		PlayOneShot(audio, looping);
	}
}
