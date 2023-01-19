using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Image BackGround;
    public GameObject NewStart;
    public GameObject Load;
    public GameObject Option;
    public GameObject Title1;
    public GameObject Title2;
    public AudioSource Bgm;
    public GameObject WriteName;
    // Start is called before the first frame update
    public void StartButton()
    {
        Title1.SetActive(false);
        Title2.SetActive(false);
        NewStart.SetActive(false);
        Load.SetActive(false);
        Option.SetActive(false);
        StartCoroutine(fadeOut());

    }
    // Update is called once per frame
    IEnumerator fadeOut()
    {
        BGMCtrl.Opening = false;
        float fadeCount = 1;
        while(fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            BackGround.color = new Color(255, 255, 255, fadeCount);
            Bgm.volume = fadeCount;
        }
        WriteName.SetActive(true);
    }
}
