using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using System;

public class newTemperatureChange : MonoBehaviour
{
    public XRController controller = null;
    public Text temperatureText;
    float currentTemperature;
    public float beginTemperature = 20;
    public float endTemperature = 25;

    // even: at begin state, uneven: at end state
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTemperature = beginTemperature;
        temperatureText.text = currentTemperature.ToString("F1") + "°C";
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerValue;
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            // if begin --> end state, increase temperature
            if (count % 2 == 0) { currentTemperature = endTemperature; }

            // if end --> begin state, decrease temperature
            if (count % 2 != 0) { currentTemperature = beginTemperature; }

            count += 1;
            temperatureText.text = currentTemperature.ToString("F1") + "°C";
        }
    }
}
