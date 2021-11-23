using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temperatureChange : MonoBehaviour
{
    public Text temperatureText;
    [Range(15, 40)] public float beginTemperature = 20;
    [Range(15, 40)] public float endTemperature = 25;
    float currentTemperature;

    bool beginState;
    bool endState;
    bool newState = false;

    // Variables for time that it takes to complete bleaching event
    public int maxTime = 10;
    int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTemperature = beginTemperature;
    }

    void TempIncrease()
    // Temperature increases, causing bleaching event. Begin to end state.
    // Decreases as long as currentTemperature is higher than endTemperature.
    {
        if (time >= maxTime)
        {
            if (currentTemperature < endTemperature)
            {
                currentTemperature += 0.1f;
                time = 0;
            }
        }

        time += 1;
    }

    void TempDecrease()
    // Temperature decreases, causing healing event. End to begin state.
    // Increases as long as currentTemperature is lower dan beginTemperature.
    {
        if (time >= maxTime)
        {
            if (currentTemperature > beginTemperature)
            {
                currentTemperature -= 0.1f;
                time = 0;
            }
        }

        time += 1;
    }

    void DecideState()
    {
        // At begin state
        if (currentTemperature == beginTemperature) { beginState = true; }

        //At end state
        if (currentTemperature == endTemperature) { endState = true; }
    }

    // Update is called once per frame
    void Update()
    {
        // if user presses button <-- needs to be added
        newState = true;

        Debug.Log("currentTemp = " + currentTemperature + " and beginTemp = " + beginTemperature + " and endTemp = " + endTemperature);
        Debug.Log("new state = " + newState);
        Debug.Log("begin state = " + beginState);
        Debug.Log("end state = " + endState);

        if (newState == true)
        {
            DecideState();

            // At begin state, to end state
            if (beginState == true && endState == false)
            {
                TempIncrease();

                // if at end state
                if (currentTemperature >= endTemperature)
                {
                    currentTemperature = endTemperature;
                    newState = false;
                    beginState = false;
                }
            }

            // At end state, to begin state
            if (beginState == false && endState == true)
            {
                TempDecrease();

                // if at begin state
                if (currentTemperature <= beginTemperature)
                {
                    currentTemperature = beginTemperature;
                    newState = false;
                    endState = false;
                }
            }
        }

        temperatureText.text = currentTemperature.ToString("F1") + "°C";
    }
}
