using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
	public VisualElement Root { get; private set; }
	public Button NavigationButton { get; private set; }
	private List<IMenuHandler> MenuHandlers { get; } = new();
	private readonly Stack<IMenuHandler> _history = new();

	public void SetNavbarText(string text = "")
	{
		var label = Root.Q<Label>("navBarLabel");
		if (label != null)
		{
			label.text = text.ToUpper();
		}
	}


	public void NavigateTo<T>() where T : IMenuHandler
	{
		if (_history.Count > 0)
		{
			AudioManager.Play("squish-3");
		}

		SetNavbarText();
		var menu = GetHandler<T>();
		if (_history.TryPeek(out var last))
		{
			last.Activate(false);
		}

		_history.Push(menu);
		menu.Activate(true);
		NavigationButton?.Display(menu.HasNavigation);
		
	}

	private void Back()
	{
		if (_history.Count <= 1)
		{
			return;
		}
		_history.Pop().Activate(false);
		_history.Peek().Activate(true);
		NavigationButton?.Display(_history.Count > 1);
		AudioManager.Play("sizzle-1");
	}

	private void Start()
	{
		Root = GetComponent<UIDocument>().rootVisualElement;
		InputManager.Instance.EventSystem.SetSelectedGameObject(gameObject);
		SetupNavigation();
		SetupHandlers();
		NavigateTo<MainMenuHandler>();

		SetupAudio();

	}

	private void SetupAudio()
	{
		void Move(NavigationMoveEvent evt)
		{
			string clipName = evt.direction switch
			{
				NavigationMoveEvent.Direction.Up => "squish-1",
				NavigationMoveEvent.Direction.Down => "squish-2",
				_ => null,
			};
			if (clipName != null)
			{
				AudioManager.Play(clipName);
			}
		}

		Root.RegisterCallback<NavigationMoveEvent>(Move);
	}



	private IMenuHandler GetHandler<T>() where T : IMenuHandler => MenuHandlers.OfType<T>().FirstOrDefault();


	private void SetupHandlers()
	{
		foreach (Type type in GetType().Assembly.GetTypes().Where(t => !t.IsAbstract && typeof(IMenuHandler).IsAssignableFrom(t)))
		{
			MenuHandlers.Add(Activator.CreateInstance(type) as IMenuHandler);
		}
		
		foreach (IMenuHandler menuHandler in MenuHandlers)
		{
			menuHandler.Bind(this);
			menuHandler.Activate(false);
		}
	}

	private void SetupNavigation()
	{
		void OnActionOnperformed(InputAction.CallbackContext context)
		{
			foreach (PlayerController playerController in InputManager.PlayerControllers)
			{
				if (playerController.PlayerInput.devices.Contains(context.control.device))
				{
					return;
				}
			}
			
			Back();
		}
		
		InputManager.Instance.InputSystem.cancel.action.performed += OnActionOnperformed;
		var _navigation = Root.Q("navigation");
		NavigationButton = Root.Q<Button>("back");
		NavigationButton.BindValue(Back);
		
		_navigation.RegisterCallback<NavigationMoveEvent>(e =>
		{
			var target = e.direction switch
			{
				NavigationMoveEvent.Direction.Up =>  _history.Peek().Element.Query<BindableElement>().Last(), 
				NavigationMoveEvent.Direction.Down => _history.Peek().Element.Query<BindableElement>().First(), 
				_ => null,
			};
			
			target?.Focus();
			e.PreventDefault();
		});
	}
}