using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewStart : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip Click;
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

}
