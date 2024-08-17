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

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn game objects every 5 seconds
    //create a coroutine of type IEnumerator -- Yield Events
    //while loop


    IEnumerator SpawnRoutine() 
    {
        //while loop (inifinite loop)
        //Instantiate enemy prefab
        //yield wait 5 seconds

        //yield return null; //wait 1 frame
        //yield return new WaitForSeconds(5.0f); //wait 5 seconds

        while (_stopSpawning == false) 
        {
            Vector3 posTosSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posTosSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(waitTime);
        };
    }

    public void OnPlayerDeath() 
    {
        _stopSpawning = true;
    }
}
