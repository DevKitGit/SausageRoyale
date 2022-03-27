using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class VisualPlayer
{
	private const string LockedInString = "player__locked-in";
	
	public PlayerController Controller { get; set; }
	public VisualElement Element { get; set; }
	public bool LockedIn
	{
		get => Element?.ClassListContains(LockedInString) ?? false;
		set
		{
			switch (value)
			{
				case true: Element.AddToClassList(LockedInString);break;
				default: Element.RemoveFromClassList(LockedInString);break;
			}
		}
	}
}

public class CharacterSelectMenu : IMenuHandler
{
	public bool HasNavigation => true;
	public VisualElement Element { get; private set; }
	
	private readonly List<VisualPlayer> _players = new ();
	private UI _ui;


	public IMenuHandler Bind(UI ui)
	{
		_ui = ui;
		Element = ui.Root.Q("character-select-menu");
		return this;
	}

	private void ResetChildren()
	{
		List<VisualElement> list = Element.Q("characters").Children().ToList();
		foreach (VisualElement element in list)
		{
			_players.Add(new VisualPlayer {Element = element});
			element.SetEnabled(false);
			element.style.backgroundImage = null;
		}
	}
	
	public void OnEnter()
	{
		_players.Clear();
		_ui.NavigationButton.SetEnabled(false);

		ResetChildren();
		InputManager.EnableJoining();
		InputManager.OnPlayerJoin += OnPlayerJoin;
	}

	public void OnExit()
	{
		_ui.NavigationButton.SetEnabled(true);
		InputManager.OnPlayerJoin -= OnPlayerJoin;
		InputManager.DisableJoining(true);
		ResetChildren();
	}

	private void OnPlayerJoin(PlayerController controller)
	{
		var visualPlayer = _players.FirstOrDefault(e => e.Controller == null);
		if (visualPlayer != null)
		{
			visualPlayer.Controller = controller;
			visualPlayer.Element.SetEnabled(true);
			ProcessNavigation(visualPlayer, null);
			controller.UiCancel.AddListener(e => ProcessBack(visualPlayer, e));
			controller.UISubmit.AddListener(e => ProcessLockIn(visualPlayer, e));
			controller.UiNavigate.AddListener(e => ProcessNavigation(visualPlayer, e));
		}
	}

	void ProcessBack(VisualPlayer visualPlayer, InputAction.CallbackContext context)
	{
		if (!context.performed || visualPlayer.Controller == null)
		{
			return;
		}

		if (visualPlayer.LockedIn)
		{
			visualPlayer.LockedIn = false;
			return;
		}
	}

	void ProcessLockIn(VisualPlayer visualPlayer, InputAction.CallbackContext context)
	{
		if (!context.performed || visualPlayer.Controller == null || visualPlayer.Controller.Sausage == null)
		{
			return;
		}

		visualPlayer.LockedIn = true;
	}

	void ProcessNavigation(VisualPlayer visualPlayer, InputAction.CallbackContext? context)
	{
		if (visualPlayer.LockedIn)
		{
			return;
		}
		
		var usedSausages = _players.Where(p => p.Controller != null).Select(p => p.Controller.Sausage).ToList();
		var sausages = GameManager.Assets.Sausages;
		
		if (context == null)
		{
			var availableSausages = sausages.Except(usedSausages).ToList();
			SetSausage(visualPlayer, availableSausages.FirstOrDefault());
			return;
		}

		if (!context.Value.performed)
		{
			return;
		}
		
		int dir = context.Value.ReadValue<Vector2>().x > 0 ? 1 : -1;

		int currentIndex = sausages.IndexOf(visualPlayer.Controller.Sausage);
		for (int i = 0; i < sausages.Count; i++)
		{
			currentIndex = currentIndex + dir;
			currentIndex = currentIndex >= sausages.Count ? 0 : currentIndex;
			currentIndex = currentIndex < 0 ? sausages.Count - 1 : currentIndex;

			var currentSausage = sausages[currentIndex];
			if (!usedSausages.Contains(currentSausage))
			{
				SetSausage(visualPlayer, currentSausage);
				break;
			}
		}
	}

	private void SetSausage(VisualPlayer visualPlayer, Sausage sausage)
	{
		visualPlayer.Controller.Sausage = sausage;
		visualPlayer.Element.style.backgroundImage = sausage.Texture;
		sausage.Color = visualPlayer.Element.style.borderBottomColor.value;
	}
}