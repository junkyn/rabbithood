using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TitleCtrl : MonoBehaviour
{
    public Image Title1;
    public Image Title2;
    public Image NewStart;
    public Image Load;
    public Image Option;
    public Button NewStartButton;
    public Button LoadButton;
    public Button OptionButton;
    public TextMeshProUGUI NewStartTxt;
    public TextMeshProUGUI OptionTxt;
    public TextMeshProUGUI LoadTxt;
    AudioSource audioSource;
    public AudioClip Click;

    // Start is called before the first frame update
    void Start()
    {
        Title();
        Cursor.visible = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Setting._EffectVolume;
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.clip = Click;
            audioSource.Play();
        }
    }

    void Title()
    {
        StartCoroutine(FadeTitle());
    }
    IEnumerator FadeTitle()
    {

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Title1.color = new Color(255, 255, 255, fadeCount);
        }
        fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Title2.color = new Color(255, 255, 255, fadeCount);
        }
        fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            NewStart.color = new Color(255, 255, 255, fadeCount);
            NewStartTxt.color = new Color(255, 255, 255, fadeCount);
            Load.color = new Color(255, 255, 255, fadeCount);
            LoadTxt.color = new Color(255, 255, 255, fadeCount);
            Option.color = new Color(255, 255, 255, fadeCount);
            OptionTxt.color = new Color(255, 255, 255, fadeCount);
        }
        NewStartButton.enabled = true;
        LoadButton.enabled = true;
        OptionButton.enabled = true;
    }
}
