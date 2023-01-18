using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ManaBar : MonoBehaviour
{
    [SerializeField] Mana mana;
    Slider uiSlider;
    
    void Awake()
    {
        uiSlider = GetComponent<Slider>();
        Debug.Assert(uiSlider != null, "UI Slider component is missing (somehow)...");
        Debug.Assert(mana != null, "Required reference to a Mana component");
    }
    
    void Update()
    {
        if (mana != null && uiSlider != null)
        {
            uiSlider.maxValue = mana.maxMana;
            uiSlider.minValue = mana.minMana;
            uiSlider.value = mana.currentMana;
        }
    }
}
