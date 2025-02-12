
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    
    public float lifetime = 5f;

    private float timer;

    void Start()
    {

        timer = lifetime; // set the timer to the lifetime of the object

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; // decrease the timer by the time that has passed since the last frame


        if (timer <= 0f) // if the timer is less than or equal to 0
        {
            Destroy(gameObject); // destroy the object
        }
    }
}