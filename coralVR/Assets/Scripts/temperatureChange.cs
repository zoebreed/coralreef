using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temperatureChange : MonoBehaviour
{
    public Text temperatureText;
    public float currentTemperature;
    public bool beginState;

    // Start is called before the first frame update
    void Start()
    {
        beginState = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (beginState = true && currentTemperature < 35.0f)
        {
            currentTemperature += 0.1f;
        }

        if (beginState = false && currentTemperature > 10.0f)
        {
            currentTemperature -= 0.1f;
        }

        // currentTemperature;
        temperatureText.text = currentTemperature.ToString("F1") + "°C";
    }
}
