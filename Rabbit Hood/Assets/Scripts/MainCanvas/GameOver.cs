using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Image Background;
    public Image _GameOver;
    public GameObject Button;
    public GameObject QuitWarn;
    private bool isQuit = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BackFade());
        StartCoroutine(GameFade());
    }

    // Update is called once per frame
    IEnumerator BackFade()
    {
        float fadeCount = 0;
        while (fadeCount <= 0.7f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Background.color = new Color(255, 255, 255, fadeCount);
        }
        
    }
    IEnumerator GameFade()
    {
        float fadeCount = 0;
        while (fadeCount < 1f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            _GameOver.color = new Color(255, 255, 255, fadeCount);
        }
        Button.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void GoOpening()
    {
        isQuit = false;
        QuitWarn.SetActive(true);
    }
    public void QuitGame()
    {
        isQuit = true;
        QuitWarn.SetActive(true);
    }
    public void QuitYes()
    {
        if (isQuit == false)
            SceneManager.LoadScene("Opening");
        else
            Application.Quit();


    }
    public void QuitNo()
    {
        QuitWarn.SetActive(false);
    }
}
