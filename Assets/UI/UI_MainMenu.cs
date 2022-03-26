using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_MainMenu : MonoBehaviour
{
    [SerializeField]
    private UIDocument _uiDocument;

    [SerializeField]
    private UIDocument _optionsDocument;

    [SerializeField]
    private UIDocument _characterSelectDocument;
    
    void OnEnable()
    { 
	    var root = _uiDocument.rootVisualElement;
	    root.Q<Button>("newgame").Focus();
	    root.Q<Button>("newgame").clicked += () =>
	    {
		    _characterSelectDocument.gameObject.SetActive(true);
		    gameObject.SetActive(false);
	    };
	    root.Q<Button>("options").clicked += () =>
	    {
		    _optionsDocument.gameObject.SetActive(true);
		    gameObject.SetActive(false);
	    };
	    root.Q<Button>("exit").clicked += () => Application.Quit();
    }
}