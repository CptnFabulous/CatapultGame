using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carShoot : MonoBehaviour {

    bool pressedFire;
    public GameObject rocketPrefab;
    
    // Use this for initialization
	void Start ()
    {
        pressedFire = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pressedFire = true;
        }
    }

    void FixedUpdate ()
    {
        if (pressedFire == true)
        {
            Instantiate(rocketPrefab, transform.position, transform.rotation);
            pressedFire = false;
        }
    }
}
