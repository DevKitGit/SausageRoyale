using System;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.NavigationMoveEvent;

public class OptionsMenu : IMenuHandler
{
	private UI _ui;
	public bool HasNavigation => true;
	public VisualElement Element { get; set; }

	public IMenuHandler Bind(UI ui)
	{
		_ui = ui;
		Element = ui.Root.Q("options-menu");
		Element.Q<Toggle>("sfx").BindDirection(ui.NavigationButton, Direction.Up);
		Element.Q<Toggle>("music").BindDirection(ui.NavigationButton, Direction.Down);
		return this;
	}

	public void OnEnter()
	{
		_ui.SetNavbarText("These options are broken");
	}

	public void OnExit()
	{
	}
}