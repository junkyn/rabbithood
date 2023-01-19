using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Click;
    public GameObject LoadGame;
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
        if (ButtonCtrl.OpenButton)
        {
            audioSource.clip = Click;
            audioSource.Play();
        }
    }
    public void OpenLoad()
    {
        if (ButtonCtrl.OpenButton)
        {
            LoadGame.SetActive(true);
            ButtonCtrl.OpenButton = false;
        }
    }

}
