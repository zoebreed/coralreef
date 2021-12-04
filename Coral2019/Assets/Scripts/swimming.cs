using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swimming : MonoBehaviour
{
    public float speed = 5f;
    public float swimTime = 5f;
    public bool goLeftFirst = true;
    float timer;
    bool toLeft;

    // public AudioSource soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        timer = swimTime;

        if (!goLeftFirst)
        {
            toLeft = false;
        }
        else
        {
            toLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(toLeft); 
        // Debug.Log(timer);

        if (toLeft)
        {
            // Move the object to the side (left) along its z axis 1 unit/second.
            // Left means: x is going into the negative direction
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            timer -= Time.deltaTime;

            // If the time is up
            if (timer <= 0f)
            { 
                // Reset timer to pre-determined swimTime
                timer = swimTime;
                toLeft = false;
                // Rotate fish 180 degrees (does not work yet)
                // transform.Rotate(0.0f, 180f, 0.0f, Space.Self);

            }

        }

        if (!toLeft)
        {
            // Move the object to the side (right) along its z axis 1 unit/second.
            // Right means: x is going into the positive direction
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            timer -= Time.deltaTime;

            // If the time is up
            if (timer <= 0f)
            {
                // Reset timer to pre-determined swimTime and rotate fish 180 degrees
                timer = swimTime;
                toLeft = true;
            }

        }

        // soundEffect.Play();
    }
}


