using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class GameAssets : ScriptableObject
{
	[field:SerializeField]
	public List<Sausage> Sausages { get; private set; }
}