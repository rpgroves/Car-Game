using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timerLength = 5.0f;
    float timer = 5.0f;
    [SerializeField] GameObject northCarPrefab;
    [SerializeField] GameObject southCarPrefab;
    [SerializeField] GameObject eastCarPrefab;
    [SerializeField] GameObject westCarPrefab;
    [SerializeField] List<GameObject> northCarSpawns = new List<GameObject>();
    [SerializeField] List<GameObject> southCarSpawns = new List<GameObject>();
    [SerializeField] List<GameObject> eastCarSpawns = new List<GameObject>();
    [SerializeField] List<GameObject> westCarSpawns = new List<GameObject>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerLength)
        {
            timer = 0.0f;
            SpawnCars();
        }
    }

    void SpawnCars()
    {
        foreach (GameObject node in northCarSpawns)
        {
            Instantiate(northCarPrefab, node.transform);
        }
        foreach (GameObject node in southCarSpawns)
        {
            Instantiate(southCarPrefab, node.transform);
        }
        foreach (GameObject node in eastCarSpawns)
        {
            Instantiate(eastCarPrefab, node.transform);
        }
        foreach (GameObject node in westCarSpawns)
        {
            Instantiate(westCarPrefab, node.transform);
        }
    }
}
