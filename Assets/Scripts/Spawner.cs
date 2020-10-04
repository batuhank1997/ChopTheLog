using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] logs;
    public float respawnTime = 1f;
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnerTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int i = Random.Range(0, 4);
        int randomNum = Random.Range(1, 4);
        GameObject log = Instantiate(logs[i]) as GameObject;

        if(randomNum == 1)
            log.transform.position = spawnPoint.transform.position;
        else if(randomNum == 2)
            log.transform.position = spawnPoint2.transform.position;
        else if (randomNum == 3)
            log.transform.position = spawnPoint3.transform.position;
    }

    IEnumerator SpawnerTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            Spawn();
        }
    }
}
