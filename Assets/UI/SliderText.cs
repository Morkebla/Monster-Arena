using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SliderText : MonoBehaviour
{
    Slider slider;
    TextMeshProUGUI text;
    
    void Awake()
    {
        slider = GetComponentInParent<Slider>();
        text = GetComponent<TextMeshProUGUI>();

        Debug.Assert(slider != null, "SliderText component needs to be placed as a child of a Slider");
        Debug.Assert(text != null, "Missing a text component (somehow)...");
    }
    
    void Update()
    {
        if (slider != null && text != null)
        {
            text.text = $"{(int)slider.value}/{(int)slider.maxValue}";
        }
    }
}
