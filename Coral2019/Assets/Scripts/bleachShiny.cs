using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleachShiny : MonoBehaviour
{
    private Renderer _renderCoral;
    public GameObject coral;

    bool endState;
    bool beginState;
    bool newState = false;

    // Variables for time that it takes to complete bleaching event
    public int maxTime = 10;
    int time = 0;

    float newValue;
    float shineBegin;
    float shineEnd;

    // Start is called before the first frame update
    void Start()
    {
        _renderCoral = coral.GetComponent<Renderer>();
        shineBegin = _renderCoral.material.GetFloat("_Shininess");
    }

    void Bleaching()
    // Bleaching event. Shininess decreases.
    // Decreases as long as newValue is bigger than shineEnd (desired value).
    {
        if (time >= maxTime)
        {
            if (newValue > shineEnd)
            {
                newValue -= 0.1f;
                time = 0;
            }
        }

        time += 1;
    }

    void Healing()
    // Bleaching event. Shininess increases.
    // Increases as long as newValue is smaller than shineBegin (desired value).
    {
        if (time >= maxTime)
        {
            if (newValue < shineBegin)
            {
                newValue += 0.1f;
                time = 0;
            }
        }

        time += 1;
    }

    void DecideState()
    {
        // At begin state
        if (newValue == shineBegin) { beginState = true; }

        //At end state
        if (newValue == shineEnd) { endState = true; }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("newValue = " + newValue + " and shineBegin = " + shineBegin + " and shineEnd = " + shineEnd);
        Debug.Log("new state = " + newState);
        Debug.Log("begin state = " + beginState);
        Debug.Log("end state = " + endState);

        // if user presses button <-- needs to be added
        newState = true;

        if (newState == true)
        {
            DecideState();

            // At begin state, to end state
            if (beginState == true && endState == false)
            {
                Bleaching();

                // if at end state
                if (newValue <= shineEnd)
                {
                    newValue = shineEnd;
                    newState = false;
                    beginState = false;
                }
            }

            // At end state, to begin state
            if (beginState == false && endState == true)
            {
                Healing();

                // if at begin state
                if (newValue >= shineBegin)
                {
                    newValue = shineBegin;
                    newState = false;
                    endState = false;
                }
            }
        }

        _renderCoral.material.SetFloat("_Shininess", newValue);

    }
}