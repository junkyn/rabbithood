using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{
    public GameObject Credit;
    public Image BackGround;
    // Start is called before the first frame update
    void Start()
    {
        FadeIn();
    }
    IEnumerator FadeIn()
    {
        float fadeCount = 0f;
        while (fadeCount < 1f)
        {
            fadeCount += 0.1f;
            BackGround.color = new Color(0,0,0,fadeCount);
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(StartCredit());
    }
    IEnumerator StartCredit()
    {
        while (Credit.transform.position.y < 300)
        {
            Credit.transform.position = new Vector2(0, Credit.transform.position.y+0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Opening");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
