using UnityEngine.UIElements;

public interface IMenuHandler
{
	bool HasNavigation { get; }
	VisualElement Element { get; }
	IMenuHandler Bind(UI ui);
}
