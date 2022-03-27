
using System;
using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class AudioManager : MonoBehaviour
{
	private static AudioManager _instance;

	public static AudioManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new GameObject().AddComponent<AudioManager>();
			}
			return _instance;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
	public static void StartGameMusic()
	{
		_instance = null;
		
		var startMusic = Play("ben-sexy", looping:true);
		startMusic.outputAudioMixerGroup = GameManager.Assets.Mixer.FindMatchingGroups("MenuSoundtrack").FirstOrDefault();
		var uiSnap = GameManager.Assets.Mixer.FindSnapshot("MainMenu");

		var gameMusic = Play("erotic-sexy", looping:true);
		gameMusic.outputAudioMixerGroup = GameManager.Assets.Mixer.FindMatchingGroups("IngameSoundtrack").FirstOrDefault();

		IEnumerator Routine()
		{
			yield return new WaitForEndOfFrame();
			uiSnap.TransitionTo(.3f);
		}

		Instance.StartCoroutine(Routine());
	}
	
	public static AudioSource Play(Audio audio, bool looping = false)
	{
		if (audio == null)
		{
			return null;
		}
		
		GameObject gameObject = new GameObject("One shot audio");
		AudioSource audioSource = (AudioSource) gameObject.AddComponent(typeof (AudioSource));
		audioSource.clip = audio.Clip;
		audioSource.spatialBlend = 0;
		audioSource.volume = 1;
		audioSource.Play();
		audioSource.loop = looping;
		DontDestroyOnLoad(audioSource.gameObject);
		if(!looping)
		{
			Object.Destroy(gameObject, audio.Clip.length * (Time.timeScale < 0.00999999977648258 ? 0.01f : Time.timeScale));
		}

		return audioSource;
	}
	
	public static AudioSource Play(string name, bool looping = false)
	{
		var audio = GameManager.Assets.Audios.FirstOrDefault(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
		if (audio == null)
		{
			Debug.LogError($"Can't find audio clip \"{name}\"");
			return null;
		}

		return Play(audio, looping);
	}
}
