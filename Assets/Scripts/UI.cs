using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
	public VisualElement Root { get; private set; }
	public Button NavigationButton { get; private set; }
	private List<IMenuHandler> MenuHandlers { get; } = new();
	private readonly Stack<IMenuHandler> _history = new();
	private VisualElement _navigation;


	public void NavigateTo<T>() where T : IMenuHandler
	{
		var menu = GetHandler<T>();
		if (_history.TryPeek(out var last))
		{
			last.Activate(false);
		}
		_history.Push(menu);
		menu.Activate(true);
		_navigation?.Display(menu.HasNavigation);
	}

	private void Back()
	{
		if (_history.Count <= 1)
		{
			return;
		}

		var last = _history.Pop();
		last.Activate(false);

		var current = _history.Peek();
		current.Activate(true);
		
		_navigation?.Display(_history.Count > 1);
		current.Element.GetFirstOfType<Button>()?.Focus();
	}

	private void Start()
	{
		Root = GetComponent<UIDocument>().rootVisualElement;
		InputManager.Instance.EventSystem.SetSelectedGameObject(gameObject);
		SetupNavigation();
		SetupHandlers();
		NavigateTo<MainMenuHandler>();
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
		InputManager.Instance.InputSystem.cancel.action.performed += context => Back();
		_navigation = Root.Q("navigation");
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