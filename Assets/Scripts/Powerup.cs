using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
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
                player.TripleShotActive();
            }
            Destroy(this.gameObject);
        }

    }

    //OnTriggerCollision
    //only be collectable by the player (HINTS: Use tags)
}
