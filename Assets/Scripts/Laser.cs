using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //speed variable of 8
    [SerializeField]
    private float _speed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //LASER MOVEMENT
        //translate laser up
        Vector3 direction = new Vector3(0, 1, 0);
        //translate laser up at 8 meters per second in real time
        transform.Translate(direction * _speed * Time.deltaTime);

        //DESTROYING THE LASER
        //if laser position is greater than 8 on the y axis
        //destroy the object
        if (transform.position.y > 8f) 
        {
            //check if this object has a parent
            //destroy the parent too
            if (transform.parent != null) 
            {
                Destroy(transform.parent.gameObject);
            }
                Destroy(this.gameObject);
        }
    }
}
