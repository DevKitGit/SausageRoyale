using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnWinners : MonoBehaviour
{
    [SerializeField] private List<Transform> sortedspawnPoints;
    
    // Start is called before the first frame update
    void Start()
    {
        sortedspawnPoints = GetComponentsInChildren<Transform>().ToList();
        sortedspawnPoints.Remove(transform);
        var sorted = FindObjectOfType<GameStateManager>().sortedSausageWinners;
        for (var index = 0; index < sorted.Count; index++)
        {
            var sC = sorted[index];
            Instantiate(GameManager.Assets.Sausages.First(s => s.Prefab.name == sC).Prefab.gameObject,sortedspawnPoints[index].position,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
