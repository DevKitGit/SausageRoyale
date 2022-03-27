using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameAssets Assets => Instance._assets;

	public static GameManager Instance { get; private set; }

	[RuntimeInitializeOnLoadMethod]
	private static void OnGameStart()
	{
		var instance = new GameObject("GAME MANAGER").AddComponent<GameManager>();
		DontDestroyOnLoad(instance);
		Instance = instance;
		Instance._assets = Resources.Load<GameAssets>("GameAssets");
	}

	private GameAssets _assets;
}
