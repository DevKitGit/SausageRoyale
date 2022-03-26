using System;
using System.Linq;
using UnityEngine;
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


	public static void BindValue(this Button button, Action action) => button.clicked += action;

	public static void Activate(this IMenuHandler instance, bool shouldDisplay)
	{
		instance?.Element?.Display(shouldDisplay);
		instance?.Element?.Query<BindableElement>().First()?.Focus();
	}

	public static void BindDirection(this BindableElement element, VisualElement target, params NavigationMoveEvent.Direction[] dirs)
	{
		if (element == null)
		{
			return;
		}
		element.RegisterCallback<NavigationMoveEvent>(e =>
		{
			if (dirs?.ToList().Contains(e.direction) ?? false)
			{
				e.PreventDefault();
				target?.Focus();
			}
		});
	}
}