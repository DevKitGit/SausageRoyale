using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    private TextManager _textManager;
    [SerializeField] private GameObject hyggePrefab;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<SausageController> spawnedSausages;
    [SerializeField] public List<string> sortedSausageWinners;


    public GameState gameState;

    public enum GameState
    {
        Starting,
        Playing,
        GameOver,
        LoadWinScene
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Starting;
        _textManager = gameObject.GetComponent<TextManager>();
        SetupGame();
        DontDestroyOnLoad(gameObject);
    }

    private void SetupGame()
    {
        StartCoroutine(_textManager.UpdateCountdown());
        for (var index = 0; index < InputManager.PlayerControllers.Count; index++)
        {
            var playerController = InputManager.PlayerControllers[index];
            SausageController sausageController =
                Instantiate(playerController.Sausage.Prefab.gameObject, spawnPoints[index].position,
                    Quaternion.Euler(90, 0,0)).gameObject.GetComponent<SausageController>();
            Canvas Canvas = Instantiate(hyggePrefab,
                sausageController.canvasFollowTransform.position,
                Quaternion.Euler(90, 0,0)).GetComponent<Canvas>();
            spawnedSausages.Add(sausageController);

            sausageController.SetPlayerController(playerController.PlayerInput);
            sausageController.SetCanvas(Canvas);
            playerController.PlayerInput.SwitchCurrentActionMap("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Starting && _textManager.doneCounting)
        {
            gameState = GameState.Playing;
            spawnedSausages.ForEach(s => s.applyFrying = true);
            //start playing sizzling sound here.
        }

        if (gameState == GameState.Playing)
        {
            SausageController winner;
            if (spawnedSausages.Count == 1)
            {
                StartCoroutine(_textManager.DoGameOver());
                winner = spawnedSausages[0];
                sortedSausageWinners.Add(winner.name.Split("(")[0]);
                spawnedSausages.Remove(winner);
                gameState = GameState.GameOver;
                return;
            }

            winner = spawnedSausages.FirstOrDefault(s => s.doneFrying);
            if (winner != null)
            {
                StartCoroutine(_textManager.DoWinner(winner.name));
                sortedSausageWinners.Add(winner.name.Split("(")[0]);
                spawnedSausages.Remove(winner);
            }
        }

        if (gameState == GameState.GameOver && _textManager.doneDeclaringWinner)
        {
            SceneManager.LoadScene(2);
            gameState = GameState.LoadWinScene;
            //scene change, use sortedSausageWinners
        }
    }

    //This function can spawn winners from prefabs onto certain spawn points that you define using a list of transforms.
    void SpawnWinners()
    {
        for (var index = 0; index < InputManager.PlayerControllers.Count; index++)
        {
            var playerController = InputManager.PlayerControllers[index];
            SausageController sausageController =
                Instantiate(playerController.Sausage.Prefab.gameObject, spawnPoints[index].position,
                    quaternion.identity).gameObject.GetComponent<SausageController>();
        }
    }
}
