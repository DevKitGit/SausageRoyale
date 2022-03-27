using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameAssets Assets => Instance._assets;

	public static GameManager Instance { get; private set; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void OnGameStart()
	{
		var instance = new GameObject("GAME MANAGER").AddComponent<GameManager>();
		DontDestroyOnLoad(instance);
		Instance = instance;
		Instance._assets = Resources.Load<GameAssets>("GameAssets");
	}

	public static void LoadMainScene()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}

	private GameAssets _assets;
}
