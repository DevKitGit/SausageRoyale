using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager Instance { get; private set; }


	
	[RuntimeInitializeOnLoadMethod]
	private static void OnGameStart()
	{
		var instance = new GameObject("GAME MANAGER").AddComponent<GameManager>();
		DontDestroyOnLoad(instance);
		Instance = instance;
	}
}
