using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnWinners : MonoBehaviour
{
    [SerializeField] private List<Transform> sortedspawnPoints;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private List<string> winners;
    
    // Start is called before the first frame update
    void Start()
    {
        sortedspawnPoints = GetComponentsInChildren<Transform>().ToList();
        sortedspawnPoints.Remove(transform);
        winners = FindObjectOfType<GameStateManager>().sortedSausageWinners.ToList();
        for (var index = 0; index < winners.Count; index++)
        {
            var sC = winners[index];
            Instantiate(GameManager.Assets.Sausages.First(s => s.Prefab.name == sC).Prefab.gameObject,sortedspawnPoints[index].position,Quaternion.Euler(-1,-1,-1));
        }
        StartCoroutine(ResetGame());
        
    }

    public IEnumerator ResetGame()
    {
        int i = 8;
        while (i != 0)
        {
            i--;
            _textMeshProUGUI.SetText($"{winners[0].ToUpper()} WINS! RESET IN {i}");
            yield return new WaitForSeconds(1);
        }
        Destroy(InputManager.Instance.gameObject);
        SceneManager.LoadScene(0);
        
    }
    // Update is called once per frame

}
