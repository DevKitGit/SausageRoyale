using System;
using UnityEngine.UIElements;

public class CharacterSelectMenu : IMenuHandler
{
	public bool HasNavigation => true;
	public VisualElement Element { get; private set; }
	
	public IMenuHandler Bind(UI ui)
	{
		Element = ui.Root.Q("character-select-menu");
		return this;
	}
}