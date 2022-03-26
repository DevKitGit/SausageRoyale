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
	    var newGame = root.Q<Button>("newgame");
	    newGame.Focus();
	    newGame.clicked += () =>
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