using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviourRocket : MonoBehaviour {

    // The fly speed (used by the weapon later)
    public float speed = 2000.0f;

    // explosion prefab (particles)
    public GameObject explosionPrefab;

    void FixedUpdate()
    {
        transform.position += transform.forward;
    }

    // find out when it hit something
    void OnCollisionEnter(Collision collidedObject)
    {
        // show an explosion
        // - transform.position because it should be
        //   where the rocket is
        // - Quaternion.identity because it should
        //   have the default rotation
        Instantiate(explosionPrefab,
                    transform.position,
                    Quaternion.identity);

        if (collidedObject.gameObject.tag == "Enemies")
        {
            Destroy (collidedObject.gameObject);
        }
        // destroy the rocket
        // note:
        //  Destroy(this) would just destroy the rocket
        //                script attached to it
        //  Destroy(gameObject) destroys the whole thing
        Destroy(gameObject);
    }
}