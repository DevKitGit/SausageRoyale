using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Rendering;

public class SplashScreenExample : MonoBehaviour
{
	private IDisposable listener;

	IEnumerator Start()
	{
		InputManager.Instance.InputSystem.enabled = false;
		listener = InputSystem.onAnyButtonPress.Call(_ => Stop());
		SplashScreen.Begin();
		
		while (!SplashScreen.isFinished)
		{
			SplashScreen.Draw();
			yield return null;
		}
	}

	private void OnDisable()
	{
		listener?.Dispose();
	}

	private void Stop()
	{
		SplashScreen.Stop(SplashScreen.StopBehavior.FadeOut);
		listener.Dispose();
		InputManager.Instance.InputSystem.enabled = true;
	}
}