using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WhiteShiny : MonoBehaviour
{
    public XRController controller = null;
    private Renderer _renderCoral;

    // even: at begin state, uneven: at end state
    int count = 0;

    float shineBegin;
    float shineEnd = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        _renderCoral = GetComponent<Renderer>();
        shineBegin = _renderCoral.material.GetFloat("_Shininess");
        _renderCoral.material.SetFloat("_Shininess", shineBegin);
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerValue;
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            // if begin --> end state, bleached corals
            if (count % 2 == 0) { _renderCoral.material.SetFloat("_Shininess", shineEnd); }

            // if end --> begin state, healthy corals
            if (count % 2 != 0) { _renderCoral.material.SetFloat("_Shininess", shineBegin); }

            count += 1;
        }
    }
}
