// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temperatureChange : MonoBehaviour
{
    public Text temperatureText;
    public double currentTemperature;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTemperature -= 1;
        temperatureText.text = currentTemperature.ToString() + "°C";
    }
}
