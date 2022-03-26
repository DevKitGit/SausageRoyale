using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class InputManager : MonoBehaviour
{
	[field:SerializeField]
	public InputSystemUIInputModule InputSystem {get; private set; }

	[field:SerializeField]
	public PlayerInputManager PlayerInputManager {get; private set; }

	[field:SerializeField]
	public EventSystem EventSystem {get; private set; }
	
	public static InputManager Instance { get; private set; }
    
	private readonly List<PlayerController> _controllers = new List<PlayerController>();

	public static List<PlayerController> PlayerControllers => Instance._controllers;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Instance = this;

	}

	public static void AddPlayer(PlayerController controller)
	{
		PlayerControllers.Add(controller);
		DontDestroyOnLoad(controller);
	}
}