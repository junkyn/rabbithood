using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EffectVolume : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = Setting._EffectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        Setting._EffectVolume = slider.value;
    }
}
