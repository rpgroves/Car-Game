using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Config")]
    public bool spawnCars = true;
    public bool randomSpawn = true;
    public float spawnTimerLength = 5.0f;
    public int randomFactor = 5;
    float spawnTimer = 5.0f;
    public GameObject northCarPrefab;
    public GameObject southCarPrefab;
    public GameObject eastCarPrefab;
    public GameObject westCarPrefab;
    public GameObject passengerPrefab;
    public GameObject destinationPrefab;
    public List<GameObject> northCarSpawns = new List<GameObject>();
    public List<GameObject> southCarSpawns = new List<GameObject>();
    public List<GameObject> eastCarSpawns = new List<GameObject>();
    public List<GameObject> westCarSpawns = new List<GameObject>();
    public List<TripNode> passengerSpawns = new List<TripNode>();
    public List<TripNode> destinationSpawns = new List<TripNode>();


    void Start()
    {
        //SpawnPassenger();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCars){
            HandleCarSpawns();
        }
        
    }

    void HandleCarSpawns()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > spawnTimerLength)
        {
            spawnTimer = 0.0f;
            SpawnCars();
        }
    }

    void SpawnCars()
    {
        foreach (GameObject node in northCarSpawns)
        {
            if(!randomSpawn)
            {
                Instantiate(northCarPrefab, node.transform);
                continue;
            }
            int random = Random.Range(0, randomFactor);
            if(random == 1)
                Instantiate(northCarPrefab, node.transform);
        }
        foreach (GameObject node in southCarSpawns)
        {
            if(!randomSpawn)
            {
                Instantiate(southCarPrefab, node.transform);
                continue;
            }
            int random = Random.Range(0, randomFactor);
            if(random == 1)
                Instantiate(southCarPrefab, node.transform);
        }
        foreach (GameObject node in eastCarSpawns)
        {
            if(!randomSpawn)
            {
                Instantiate(eastCarPrefab, node.transform);
                continue;
            }
            int random = Random.Range(0, randomFactor);
            if(random == 1)
                Instantiate(eastCarPrefab, node.transform);
        }
        foreach (GameObject node in westCarSpawns)
        {
            if(!randomSpawn)
            {
                Instantiate(westCarPrefab, node.transform);
                continue;
            }
            int random = Random.Range(0, randomFactor);
            if(random == 1)
                Instantiate(westCarPrefab, node.transform);
        }
    }

    void SpawnPassenger()
    {
        // foreach (GameObject node in passengerSpawns)
        // {
        //     if(!node.GetComponent<PassengerSpawnNode>().GetHasPassenger())
        //     {
        //         node.GetComponent<PassengerSpawnNode>().SpawnPassenger(passengerPrefab);
        //         node.GetComponent<PassengerSpawnNode>().SetHasPassenger(true);
        //     }
        // }
        // foreach (GameObject node in destinationSpawns)
        // {
        //     if(!node.GetComponent<DestinationSpawnNode>().GetHasDestination())
        //     {
        //         node.GetComponent<DestinationSpawnNode>().SpawnDestination(destinationPrefab);
        //         node.GetComponent<DestinationSpawnNode>().SetHasDestination(true);
        //     }
        // }
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
