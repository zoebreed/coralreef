using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WhiteCubemap : MonoBehaviour
{
    public XRController controller = null;
    private Renderer _renderCoral;

    // even: at begin state, uneven: at end state
    int count = 0;

    Color newColor;
    Vector4 beginColor;

    // Values of RGB of end state
    [Range(0, 3)] public float rEnd = 1;
    [Range(0, 3)] public float gEnd = 1;
    [Range(0, 3)] public float bEnd = 1;

    // Start is called before the first frame update
    void Start()
    {
        _renderCoral = GetComponent<Renderer>();
        beginColor = _renderCoral.material.GetVector("_CubemapColor");
        _renderCoral.material.SetColor("_CubemapColor", beginColor);
    }

    // Update is called once per frame
    void Update()
    {
        bool triggerValue;
        if (controller.inputDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            // if begin --> end state, bleached corals
            if (count % 2 == 0) { newColor = new Vector4(rEnd, gEnd, bEnd); }

            // if end --> begin state, healthy corals
            if (count % 2 != 0) { newColor = beginColor; }

            _renderCoral.material.SetColor("_CubemapColor", newColor);
            count += 1;

        }
    }
}
