using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleachCubemap : MonoBehaviour
{
    private Renderer _renderCoral;
    public GameObject coral;

    bool endState;
    bool beginState;
    bool newState = false;
    Color newColor;

    // Variables for time that it takes to complete bleaching event
    public int maxTime = 10;
    int time = 0;

    // Values of RGB of begin state
    [Range(0, 3)] public float rBegin;
    [Range(0, 3)] public float gBegin;
    [Range(0, 3)] public float bBegin;

    // Values of RGB of end state
    [Range(0, 3)] public float rEnd;
    [Range(0, 3)] public float gEnd;
    [Range(0, 3)] public float bEnd;

    // Values that will change
    float r;
    float g;
    float b;

    // Start is called before the first frame update
    void Start()
    {
        _renderCoral = coral.GetComponent<Renderer>();
        newColor = new Vector4(rBegin, gBegin, bBegin);
        r = rBegin;
        g = gBegin;
        b = bBegin;
    }

    void Bleaching()
    // Bleaching event. RGB values increase.
    // Increases as long as r is not equal to rEnd.
    {
        if (time >= maxTime)
        {
            if (r < rEnd)
            {
                r += 0.1f;
                g += 0.1f;
                b += 0.1f;
                time = 0;
            }
        }

        time += 1;
        newColor = new Vector4(r, g, b);
    }

    void Healing()
    // Healing event. RGB values decrease.
    // Decreases as long as r is not equal to rBegin.
    {
        if (time >= maxTime)
        {
            if (r > rBegin)
            {
                r -= 0.1f;
                g -= 0.1f;
                b -= 0.1f;
                time = 0;
            }
        }

        time += 1;
        newColor = new Vector4(r, g, b);
    }

    void DecideState()
    {
        // At begin state
        if (r == rBegin) { beginState = true; }

        // At end state
        if (r == rEnd) { endState = true; }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("r = " + r + " and rbegin = " + rBegin + " and rEnd = " + rEnd);
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
                if (r >= rEnd)
                {
                    r = rEnd;
                    newState = false;
                    beginState = false;
                }
            }

            // At endstate, to begin state
            if (beginState == false && endState == true)
            {
                Healing();

                // if at begin state
                if (r <= rBegin)
                {
                    r = rBegin;
                    newState = false;
                    endState = false;
                }
            }
        }

        _renderCoral.material.SetColor("_CubemapColor", newColor);

    }
}