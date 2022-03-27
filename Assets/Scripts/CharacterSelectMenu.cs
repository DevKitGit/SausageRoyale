using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class VisualPlayer
{
	public int Id { get; set; }
	public PlayerController Controller { get; set; }
	public VisualElement Element { get; set; }
}

public class CharacterSelectMenu : IMenuHandler
{
	public bool HasNavigation => true;
	public VisualElement Element { get; private set; }
	
	private readonly List<VisualPlayer> _players = new ();
	
	
	public IMenuHandler Bind(UI ui)
	{
		Element = ui.Root.Q("character-select-menu");
		return this;
	}

	public void OnEnter()
	{
		_players.Clear();
		List<VisualElement> list = Element.Q("characters").Children().ToList();
		for (var i = 0; i < list.Count; i++)
		{
			var element = list[i];
			_players.Add(new VisualPlayer {Element = element, Id = i});
			element.SetEnabled(false);
		}

		InputManager.EnableJoining();

		InputManager.OnPlayerJoin += OnPlayerJoin;
	}

	private void ProcessPlayer(PlayerController player, bool isAdding)
	{
		
	}

	private void OnPlayerJoin(PlayerController controller)
	{
		var visualPlayer = _players.FirstOrDefault(e => e.Controller == null);
		if (visualPlayer != null)
		{
			visualPlayer.Controller = controller;

			ProcessNavigation(null, visualPlayer);
			controller.UiNavigate.AddListener(e => ProcessNavigation(e, visualPlayer));
		}

	}


	void ProcessNavigation(InputAction.CallbackContext? context, VisualPlayer visualPlayer)
	{
		var usedSausages = _players.Select(p => p.Controller.Sausage);
		var sausages = GameManager.Assets.Sausages;
		
		if (context == null)
		{
			var availableSausages = sausages.Except(usedSausages).ToList();
			visualPlayer.Controller.Sausage = availableSausages.FirstOrDefault();
			return;
		}

		int dir = context.Value.ReadValue<Vector2>().x > 0 ? 1 : -1;

		for (int i = 0; i < sausages.Count; i++)
		{
			
		}
		
		// visualPlayer.Controller.
		// visualPlayer.Controller.
		// GameManager.Assets.Sausages
	}

	public void OnExit()
	{
		InputManager.OnPlayerJoin -= OnPlayerJoin;
		InputManager.DisableJoining(true);
		// foreach (var character in _characterElements)
		// {
		// 	character.SetEnabled(false);
		// }
	}
}