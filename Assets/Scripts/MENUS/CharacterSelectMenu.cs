using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;


public class CharacterSelectMenu : IMenuHandler
{
	public bool HasNavigation => true;
	public VisualElement Element { get; private set; }
	
	private readonly List<VisualPlayer> _players = new ();
	private UI _ui;

	private int LockedInCount => _players.Count(p => p.LockedIn);
	private int ValidCount => _players.Count(p => p.IsValid);

	private IEnumerator _countDown;
	
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
		_ui.SetNavbarText("Press a button to join");
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
			AudioManager.Play("squish-2");
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

		AudioManager.Play("back-1");
		if (visualPlayer.LockedIn)
		{
			visualPlayer.LockedIn = false;
			GameManager.Stop(_countDown);
			_ui.SetNavbarText("Press a button to join");
			_countDown = null;
		}
		else
		{
			visualPlayer.Reset();
		}
	}

	void ProcessLockIn(VisualPlayer visualPlayer, InputAction.CallbackContext context)
	{
		if (visualPlayer.LockedIn || !context.performed || visualPlayer.Controller == null || visualPlayer.Controller.Sausage == null)
		{
			return;
		}

		visualPlayer.LockedIn = true;
		AudioManager.Play("squish-3");
		
		if (_countDown == null && LockedInCount == ValidCount && ValidCount > 1)
		{

			_countDown = GameManager.Start(DoCountDown());
		}
	}

	IEnumerator DoCountDown()
	{
		var seconds = 3;
		var failed = false;
		
		for (int i = 0; i < seconds; i++)
		{
			string num = i switch
			{
				0 => "THREE",
				1 => "TWO",
				2 => "ONE",
				_ => "throw new ArgumentOutOfRangeException()",
			};
			
			_ui.SetNavbarText($"All players ready! {num}!");
			yield return new WaitForSeconds(1);
			if (LockedInCount != ValidCount || ValidCount <= 1)
			{
				failed = true;
				break;
			}
		}

		if (!failed)
		{
			GameManager.LoadMainScene();
		}

		_countDown = null;
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
		
		AudioManager.Play("squish-2");
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
	
	private class VisualPlayer
	{
		private const string LockedInString = "player__locked-in";

		public void Reset()
		{
			Element.SetEnabled(false);
			Element.style.backgroundImage = null;
			if (Controller == null)
			{
				return;
			}
			InputManager.RemovePlayer(Controller);
			InputManager.Instance.InputSystem.enabled = false;
			InputManager.Instance.InputSystem.enabled = true;
		}
		
		public bool IsValid => Controller != null;
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
}