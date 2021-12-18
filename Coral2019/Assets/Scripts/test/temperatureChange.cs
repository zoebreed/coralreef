using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class temperatureChange : MonoBehaviour
{
    public XRController controller = null;
    public Text temperatureText;
    [Range(15, 40)] public float beginTemperature = 20;
    [Range(15, 40)] public float endTemperature = 25;
    float currentTemperature;

    bool beginState = true;
    bool endState = false;
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
    // Increases as long as currentTemperature is lower than endTemperature.
    {
        if (time >= maxTime)
        {
            currentTemperature += 0.1f;
            time = 0;
        }

        time += 1;
    }

    void TempDecrease()
    // Temperature decreases, causing healing event. End to begin state.
    // Decreases as long as currentTemperature is higher than beginTemperature.
    {
        if (time >= maxTime)
        {
            currentTemperature -= 0.1f;
            time = 0;
        }

        time += 1;
    }

    void DecideState()
    {
        // At begin state
        if (currentTemperature == beginTemperature)
            beginState = true;

        // At end state
        if (currentTemperature == endTemperature)
            endState = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if user presses button on the back of the Oculus Controller
        bool triggerValue;
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
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
                    while (currentTemperature < endTemperature)
                    {
                        TempIncrease();
                    }

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
                    while (currentTemperature < beginTemperature)
                    {
                        TempDecrease();
                    }

                    // if at begin state
                    if (currentTemperature <= beginTemperature)
                    {
                        currentTemperature = beginTemperature;
                        newState = false;
                        endState = false;
                    }
                }
            }
        }

        temperatureText.text = currentTemperature.ToString("F1") + "°C";
    }
}
