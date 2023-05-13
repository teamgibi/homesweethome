using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class BrightnessController : MonoBehaviour
{
    public Slider BrightnessSlider;
    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    AutoExposure exposure;

    void Start()
    {
        brightness.TryGetSettings(out exposure);
        AdjustBrightness(BrightnessSlider.value);
    } 

    public void AdjustBrightness(float value)
    {
        if (value != 0)
        {
            exposure.keyValue.value = value;
        }
        else
        {
            exposure.keyValue.value = .05f;
        }
    }
}