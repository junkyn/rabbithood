using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Click;
    public GameObject OptionMenu;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Setting._EffectVolume;
    }
    public void ClickSound()
    {
        audioSource.clip = Click;
        audioSource.Play();
    }
    public void OpenOption()
    {
        OptionMenu.SetActive(true);
    }
    public void CloseOption()
    {
        OptionMenu.SetActive(false);
        DataManager.instance.nowSetting.MainVolume = Setting._MainVolume;
        DataManager.instance.nowSetting.EffectVolume = Setting._EffectVolume;
        DataManager.instance.nowSetting.IsFullScreen = Setting.isFullScreen;
        DataManager.instance.SaveSetting();
        Debug.Log(DataManager.instance.nowSetting.MainVolume);
    }
}
