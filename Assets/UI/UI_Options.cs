using UnityEngine;
using UnityEngine.UIElements;

public class UI_Options : MonoBehaviour
{
	[SerializeField]
	private UIDocument _uiDocument;

	[SerializeField]
	private UIDocument _mainMenuDocument;
	
	void OnEnable()
	{ 
		var root = _uiDocument.rootVisualElement;
		root.Q<Button>().Focus();
		root.Q<Button>("back").clicked += () =>
		{
			_mainMenuDocument.gameObject.SetActive(true);
			gameObject.SetActive(false);
		};
	}
}