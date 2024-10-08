﻿using System.Collections;
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
    private float _speedMultiplier = 2;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    //variable for isTripleShotActive
    private bool _isTripleShotActive = false;
    private bool _isSpeedBoostActive = false;
    private bool _isShieldsActive = false;
    [SerializeField]
    private GameObject _tripleShotPrefab;

    //variable reference to the shield visualizer
    [SerializeField]
    private GameObject _shieldVisualizer;


    // Start is called before the first frame update
    void Start()
    {
        //take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }
        
    }

    // Update is called once per frame
    void Update() 
    {
        CalculateMovement();

        //if space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) {
            FireLaser();
        }

    }

    void CalculateMovement() {
        float horiziontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //new Vector3(1, 0, 0) * 3.5 * horizontalInput * real time
        //transform.Translate(Vector3.right * _speed * horiziontalInput * Time.deltaTime);
        //new Vector3(0, 1, 0) * 3.5 * verticalInput * real time
        //transform.Translate(Vector3.up * _speed * verticalInput * Time.deltaTime);
        //transform.Translate(new Vector3(horiziontalInput, verticalInput, 0) * _speed * Time.deltaTime);
        Vector3 direction = new Vector3(horiziontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        // PLAYER BOUNDARIES ON THE Y AXIS
        //if player position on the y is greater than 0
        //y position = 0
        //else if player position on the y is less than -3.8
        //y position = -3.8

        //Using Mathf.Clamp to limit the player's movement on the y axis instead of using if statements
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        // PLAYER BOUNDARIES ON THE X AXIS with wrap around
        //if player position on the x is greater than 10.25
        //x position = -10.25
        //else if player position on the x is less than -10.25
        //x position = 10.25
        if (transform.position.x >= 10.25f) {
            transform.position = new Vector3(-10.25f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10.25f) {
            transform.position = new Vector3(10.25f, transform.position.y, 0);
        }
    }

    void FireLaser() 
    {
        _canFire = Time.time + _fireRate;

        if (_isTripleShotActive) {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else 
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
    }

    public void Damage() 
    {
        //if shields are active
        //do nothing...
        //deactivate the shields
        //return

        if (_isShieldsActive == true) 
        {
            _isShieldsActive = false;
            _shieldVisualizer.SetActive(false);
            return;
        }
        _lives --;

        if ( _lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive() 
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine() 
    {
        while(_isTripleShotActive == true) 
        {
            yield return new WaitForSeconds(5.0f);
            _isTripleShotActive = false;
        }
    }

    public void SpeedBoostActive() 
    {
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine() 
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedBoostActive = false;
        _speed /= _speedMultiplier;
        
    }

    public void ShieldsActive() 
    {
        _isShieldsActive = true;
        _shieldVisualizer.SetActive(true);
    }

}
