using UnityEngine;

[CreateAssetMenu]
public class Sausage : ScriptableObject
{
	public string Name => name;
	
	[field:SerializeField]
	public GameObject Prefab { get; private set; }
	
	[field:SerializeField]
	public Color Color { get; private set; } 
	
	[field:SerializeField]
	public Texture2D Texture { get; private set; } 
}