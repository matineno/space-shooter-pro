using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 5.0f;

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] powerups;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn game objects every 5 seconds
    //create a coroutine of type IEnumerator -- Yield Events
    //while loop


    IEnumerator SpawnEnemyRoutine() 
    {
        //while loop (inifinite loop)
        //Instantiate enemy prefab
        //yield wait 5 seconds

        //yield return null; //wait 1 frame
        //yield return new WaitForSeconds(5.0f); //wait 5 seconds

        while (_stopSpawning == false) 
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(waitTime);
        };
    }

    IEnumerator SpawnPowerupRoutine() 
    {
        //every 3-7 seconds, spawn in a powerup
        while (_stopSpawning == false) {
            Vector3 PosToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], PosToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        };
    }

    public void OnPlayerDeath() 
    {
        _stopSpawning = true;
    }
}
