using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class animalStates : MonoBehaviour
{
    public XRController controller = null;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool triggerValue;
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            // if begin --> end state, make fish disappear
            if (count % 2 == 0) { transform.localScale = new Vector3(0, 0, 0); }

            // if end --> begin state, make fish appear
            if (count % 2 != 0) { transform.localScale = new Vector3(1, 1, 1); }

            count += 1;
        }
    }
}
