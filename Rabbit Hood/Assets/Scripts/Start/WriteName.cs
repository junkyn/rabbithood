using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class WriteName : MonoBehaviour
{
    public Image NameColor;
    public TextMeshProUGUI Question;
    public GameObject NameInputField;
    public Image NameInput;
    public TMP_InputField NameField;
    public GameObject ConfirmName;
    public TextMeshProUGUI IsRight;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Name());
    }

    IEnumerator Name()
    {
        float fadeCount = 0;
        while (fadeCount < 1)
        {
            fadeCount+=0.02f;
            yield return new WaitForSeconds(0.01f);
            NameColor.color = new Color(255, 255, 255, fadeCount);
        }
        fadeCount = 0;
        while (fadeCount < 1)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Question.color = new Color(255, 255, 255, fadeCount);
        }
        NameInputField.SetActive(true);
    }
    // Update is called once per frame
    public void EnterName()
    {
        IsRight.text = NameField.text + "(이)가 맞습니까?";
        ConfirmName.SetActive(true);
    }
    public void YesName()
    {
        DataManager.instance.nowPlayer.Name = NameField.text;
        SceneManager.LoadScene("Main");
    }
    public void NoName()
    {
        NameField.text = null;
        ConfirmName.SetActive (false);
    }
}
