using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuHandler : IMenuHandler
{
	public bool HasNavigation => false;
	public VisualElement Element { get; set; }

	public IMenuHandler Bind(UI ui)
	{
		Element = ui.Root.Q("main-menu");
		
		var optionsButton = Element.Q<Button>("options");
		optionsButton.BindValue(ui.NavigateTo<OptionsMenu>);
		var newGameButton = Element.Q<Button>("newgame");
		newGameButton.BindValue(ui.NavigateTo<CharacterSelectMenu>);
		var exitButton = Element.Q<Button>("exit");
		exitButton.BindValue(Application.Quit);
		
		return this;
	}

	public void OnEnter()
	{
		
	}

	public void OnExit()
	{
	}
}