using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    [SerializeField]
    private GameObject _ememyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        float randomX = Random.Range(-8f, 8f);
        transform.position = new Vector3(randomX, 7, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters per second
        Vector3 direction = new Vector3(0, -1, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        //if bottom of screen, respawn at top at a random x position
        if (transform.position.y < -5f) 
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {   
        //if other is Player
        //Destroy Us
        //Damage the player
        if (other.tag == "Player") 
        {
            Destroy(this.gameObject);
        }

        //if other is laser
        //laser
        //destroy us
        if (other.tag == "Laser") 
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        Debug.Log("Hit: " + other.transform.name);
    }
}
