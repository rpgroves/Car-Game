using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float spawnTimerLength = 5.0f;
    float spawnTimer = 5.0f;
    [SerializeField] float passengerTimerLength = 5.0f;
    float passengerTimer = 5.0f;
    [SerializeField] GameObject northCarPrefab;
    [SerializeField] GameObject southCarPrefab;
    [SerializeField] GameObject eastCarPrefab;
    [SerializeField] GameObject westCarPrefab;
    [SerializeField] GameObject passengerPrefab;
    [SerializeField] GameObject destinationPrefab;
    [SerializeField] List<GameObject> northCarSpawns = new List<GameObject>();
    [SerializeField] List<GameObject> southCarSpawns = new List<GameObject>();
    [SerializeField] List<GameObject> eastCarSpawns = new List<GameObject>();
    [SerializeField] List<GameObject> westCarSpawns = new List<GameObject>();
    [SerializeField] List<GameObject> passengerSpawns = new List<GameObject>();
    [SerializeField] List<GameObject> destinationSpawns = new List<GameObject>();

    void Start()
    {
        //SpawnPassenger();
    }

    // Update is called once per frame
    void Update()
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

    void SpawnPassenger()
    {
        foreach (GameObject node in passengerSpawns)
        {
            if(!node.GetComponent<PassengerSpawnNode>().GetHasPassenger())
            {
                node.GetComponent<PassengerSpawnNode>().SpawnPassenger(passengerPrefab);
                node.GetComponent<PassengerSpawnNode>().SetHasPassenger(true);
            }
        }
        foreach (GameObject node in destinationSpawns)
        {
            if(!node.GetComponent<DestinationSpawnNode>().GetHasDestination())
            {
                node.GetComponent<DestinationSpawnNode>().SpawnDestination(destinationPrefab);
                node.GetComponent<DestinationSpawnNode>().SetHasDestination(true);
            }
        }
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
