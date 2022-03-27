using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private TextManager _textManager;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<SausageController> spawnedSausages;
    [SerializeField] private List<SausageController> sortedSausageWinners;

    public GameState gameState;
    public enum GameState
    {
        Starting,
        Playing,
        GameOver
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Starting;
        _textManager = gameObject.GetComponent<TextManager>();
        SetupGame();
    }

    private void SetupGame()
    {
        StartCoroutine(_textManager.UpdateCountdown());
        for (var index = 0; index < InputManager.PlayerControllers.Count; index++)
        {
            var playerController = InputManager.PlayerControllers[index];
            spawnedSausages.Add(Instantiate(playerController.Sausage.Prefab.gameObject,spawnPoints[index]).gameObject.GetComponent<SausageController>());
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
        }
        if (gameState == GameState.Playing)
        {
            SausageController winner;
            if (spawnedSausages.Count == 1)
            {
                winner = spawnedSausages[0];
                gameState = GameState.GameOver;
            }
            else
            {
                winner = spawnedSausages.First(s => s.doneFrying);
            }
            sortedSausageWinners.Add(winner);
            spawnedSausages.Remove(winner);
        }

        if (gameState == GameState.GameOver)
        {
            //do stuff
        }
    }
}
