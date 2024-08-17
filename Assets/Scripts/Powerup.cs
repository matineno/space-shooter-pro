using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    //ID for powerups
    //0 = Triple Shot
    //1 = Speed
    //2 = Shields

    [SerializeField]
    private int powerupID; //0 = TripleShot, 1 = Speed, 2 = Shields

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at a speed of 3 (adjust in the inspector)
        //when we leave the screen, destroy this object
        Vector3 direction = new Vector3(0, -1, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        if (transform.position.y < -5f) 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {

       if (other.tag == "Player") 
       {
            Player player = other.transform.GetComponent<Player>();
            if (player != null) 
            {
                //if powerupID is 0, triple shot
                if (powerupID == 0) 
                {
                    player.TripleShotActive();
                    Debug.Log("Triple Shot Active");
                }
                else if (powerupID == 1) 
                {
                    Debug.Log("Speed Active");
                }
                else if (powerupID == 2) 
                {
                    Debug.Log("Shields Active");
                }

                //if powerupID is 1, speed

                //if powerupID is 2, shields

            }
            Destroy(this.gameObject);
        }

    }

    //OnTriggerCollision
    //only be collectable by the player (HINTS: Use tags)
}
