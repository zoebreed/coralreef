using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class testingController : MonoBehaviour
{
    public XRController controller = null;
    public Text temperatureText;
    public float currentTemperature;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Change()
    {
        currentTemperature += 1f;
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerValue;
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            Change();
            temperatureText.text = currentTemperature.ToString("F1") + "°C";
            Debug.Log("Trigger button is pressed.");
        }
    }
}
