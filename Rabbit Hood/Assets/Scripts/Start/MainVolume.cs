using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainVolume : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = Setting._MainVolume;
    }

    // Update is called once per frame
    void Update()
    {
        Setting._MainVolume = slider.value;
    }
}
