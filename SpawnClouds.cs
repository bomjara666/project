using UnityEngine;

public class SpawnClouds : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] spawnPoint;
    [SerializeField]
    private GameObject[] cloud;
    [SerializeField]
    private GameObject[] rocet;
    [SerializeField]
    private float spawnInterval = 4.0f;
    [SerializeField]
    private float spawnRocetInterval = 6.0f;
    void Start()
    {
        Invoke("SpawnCloud", spawnInterval);
        Invoke("SpawnRocet", spawnRocetInterval);
    }

    private void SpawnCloud()
    {
        int index = UnityEngine.Random.Range(0, 4);
        GameObject cl = Instantiate(cloud[0]);
        Vector3 posicion = spawnPoint[index].transform.position;
        cl.transform.position = posicion;
        Invoke("SpawnCloud", spawnInterval);
    }

    private void SpawnRocet()
    {
        int index = UnityEngine.Random.Range(0, 4);
        GameObject rc = Instantiate(rocet[0]);
        Vector3 posicion = spawnPoint[index].transform.position;
        rc.transform.position = posicion;
        Invoke("SpawnRocet", spawnRocetInterval);
    }
    void Update()
    {

    }
}
