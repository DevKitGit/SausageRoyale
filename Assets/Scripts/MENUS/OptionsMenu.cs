using System;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.NavigationMoveEvent;

public class OptionsMenu : IMenuHandler
{
	public UI UI { get; set; }
	public VisualElement Element => UI.Root.Q("options-menu");

	public void BindControls()
	{
		var sfxToggle = Element.Q<Toggle>("sfx");
		sfxToggle.value = AudioManager.SfxEnabled;
		sfxToggle.RegisterValueChangedCallback(e => AudioManager.SfxEnabled = e.newValue);
		
		var musicToggle = Element.Q<Toggle>("music");
		musicToggle.value = AudioManager.MusicEnabled;
		musicToggle.RegisterValueChangedCallback(e => AudioManager.MusicEnabled = e.newValue);
	}
	

	public void OnEnter()
	{
		UI.Navigation.SetNavbarText("These options are pretty neat");
	}

	public void OnExit()
	{
	}
}