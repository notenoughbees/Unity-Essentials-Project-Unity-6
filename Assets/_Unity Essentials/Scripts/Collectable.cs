//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("collectable start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("collectable update");
        //transform.Rotate(0, 1, 0); // rotate 1 degree per frame
        //transform.Rotate(0, 0.5f, 0);
        transform.Rotate(0, rotationSpeed, 0);
        //transform.Rotate(0, Time.deltaTime * 10f, 0);
    }

    // Called whenever an object with a RigidBody component collides with the collectable.
    private void OnTriggerEnter(Collider other)
    {
        // "if an*other* GameObject that collided with me has the Player tag, then..."
        if(other.CompareTag("Player")) {
            // Destroy the collectable
            Destroy(gameObject);

            // Instantiate the particle effect.
            //   transform.position refers to the position of the collectable,
            //   so we create the particle at the location the collectable was at
            //   at the time the script was attached to the collectable object.
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }

}
