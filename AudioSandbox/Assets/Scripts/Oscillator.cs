using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

    // un-optimized version
    public double frequency = 440.0;
    public double gain = 0.05;
    private double increment;
    private double phase;
    private double sampling_frequency = 48000;

    void OnAudioFilterRead(float[] data, int channels)
    {
        // update increment in case frequency has changed
        increment = frequency * 2.0 * Mathf.PI / sampling_frequency;

        for (var i = 0; i < data.Length; i += channels)
        {
            phase += increment;
            // this is where we copy audio data to make them “available” to Unity
            data[i] = (float)(gain * Mathf.Sin((float)phase));
            // if we have stereo, we copy the mono data to each channel
            if (channels == 2)
            {
                data[i + 1] = data[i];   
            }
            if (phase > (2.0 * Mathf.PI))
            {
                phase = 0.0;
            }
        }
    }
} 