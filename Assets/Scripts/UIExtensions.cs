using System;
using UnityEngine.UIElements;

public static class UIExtensions
{
	public static void Display(this VisualElement element, bool shouldDisplay)
	{
		if (element == null)
		{
			return;
		}
		
		element.style.display = shouldDisplay ? DisplayStyle.Flex : DisplayStyle.None;
	}

	public static void Replace(this VisualElement root, VisualElement oldElement, VisualElement newElement)
	{
		int index = root.IndexOf(oldElement);
		root.Insert(index, newElement);
		root.Remove(oldElement);
	}


	public static void BindValue(this Button button, Action action) => button.RegisterCallback<ClickEvent>(_ => action?.Invoke());
	
}