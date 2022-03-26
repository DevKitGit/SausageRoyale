using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
	private VisualElement _root;

	private VisualElement _mainMenu;
	private VisualElement _options;
	private VisualElement _characterSelect;

	private Stack<VisualElement> _history = new Stack<VisualElement>();
	private VisualElement _navigation;

	private void Back()
	{
		if (_history.Count <= 1)
		{
			return;
		}

		var last = _history.Pop();
		last.Display(false);

		var current = _history.Peek();
		current.Display(true);
		
		_navigation?.Display(_history.Count > 1);
		current.GetFirstOfType<Button>()?.Focus();
	}

	private void NavigateTo(VisualElement menu)
	{
		if (_history.Count == 0)
		{
			_navigation?.Display(false);
			_history.Push(menu);
			return;
		}

		var last = _history.Peek();
		last.Display(false);
		_history.Push(menu);
		menu.Display(true);
		_navigation?.Display(true);
		menu.GetFirstOfType<Button>()?.Focus();
	}
	
	private void Awake()
	{
		_root = GetComponent<UIDocument>().rootVisualElement;
		_mainMenu = _root.Q("main-menu");
		_options = _root.Q("options-menu");
		_characterSelect = _root.Q("character-select-menu");

		_mainMenu.Display(true);
		_options.Display(false);
		_characterSelect.Display(false);

		_navigation = _root.Q("navigation");
		var navigationBack = _root.Q<Button>("back");
		navigationBack.BindValue(Back);
		
		var optionsButton = _mainMenu.Q<Button>("options");
		optionsButton.BindValue(() => NavigateTo(_options));
		var newGameButton = _mainMenu.Q<Button>("newgame");
		newGameButton.BindValue(() => NavigateTo(_characterSelect));
		var exitButton = _mainMenu.Q<Button>("exit");
		exitButton.BindValue(Application.Quit);


		NavigateTo(_mainMenu);
	}

}