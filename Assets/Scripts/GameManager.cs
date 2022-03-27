using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _countdown;
	public enum Phase
	{
		UI,
		Starting,
		Playing,
		DonePlaying
	}
	public static GameManager Instance { get; private set; }

	private void Start()
	{
		StartCoroutine(UpdateCountdown());
	}
	
	private IEnumerator UpdateCountdown()
	{
		yield return new WaitForSeconds(1);
		var counter = 3;
		while(counter > 0)
		{
			_countdown.SetText(counter.ToString());
			counter--;
			yield return new WaitForSeconds(1);
		}
	}
	
	[RuntimeInitializeOnLoadMethod]
	private static void OnGameStart()
	{
		var instance = new GameObject("GAME MANAGER").AddComponent<GameManager>();
		DontDestroyOnLoad(instance);
		Instance = instance;
	}
}
