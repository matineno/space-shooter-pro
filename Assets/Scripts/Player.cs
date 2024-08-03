using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public or private reference
    //data type (int, float, bool, string)
    //every variable has a name
    //optional value assigned
    [SerializeField] //Serialize data so it can be read and modified in the inspector
    private float _speed = 3.5f;


    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update() 
    {
        float horiziontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
                            //new Vector3(1, 0, 0) * 3.5 * horizontalInput * real time
        //transform.Translate(Vector3.right * _speed * horiziontalInput * Time.deltaTime);
                            //new Vector3(0, 1, 0) * 3.5 * verticalInput * real time
        //transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        //transform.Translate(new Vector3(horiziontalInput, verticalInput, 0) * _speed * Time.deltaTime);
        Vector3 direction = new Vector3(horiziontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        //if player position on the y is greater that 0
        //y position = 0


    }
}
