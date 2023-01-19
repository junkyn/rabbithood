using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    public static bool isFullScreen = false;
    public static float _MainVolume = 1f;
    public static float _EffectVolume = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
        if (File.Exists(DataManager.instance.path + "Setting"))
        {
            Debug.Log(1);
            DataManager.instance.LoadSetting();
            isFullScreen = DataManager.instance.nowSetting.IsFullScreen;
            _MainVolume = DataManager.instance.nowSetting.MainVolume;
            _EffectVolume = DataManager.instance.nowSetting.EffectVolume;
        }
        else
        {
            _MainVolume = 1f;
            _EffectVolume = 1f;
            isFullScreen = false;

        }
        SetResolution();
    }

    public void SetResolution()
    {
        int setWidth = 1280;
        int setHeight = 720;

        Screen.SetResolution(setWidth, setHeight, isFullScreen);
    }
    // Update is called once per frame
    public void ClickFullScreen(Toggle toggle)
    {
        if (toggle.isOn)
        {
            int setWidth = 1280;
            int setHeight = 720;
            isFullScreen = true;
            Screen.SetResolution(setWidth, setHeight, isFullScreen);
            Debug.Log(isFullScreen);
        }
        else
        {
            int setWidth = 1280;
            int setHeight = 720;
            isFullScreen = false;
            Screen.SetResolution(setWidth, setHeight, isFullScreen);
            Debug.Log(isFullScreen);

        }
    }
}
