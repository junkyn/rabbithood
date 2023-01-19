using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCtrl : MonoBehaviour
{
    public GameObject Menu;
    public GameObject OptionMenu;
    public GameObject QuitWarn;
    private bool isQuit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OptionMenu.SetActive(false);
            QuitWarn.SetActive(false);
            Menu.SetActive(false);
        }
    }
    public void GoOpening()
    {
        isQuit = false;
        QuitWarn.SetActive(true);
    }
    public void OpenOption()
    {
        OptionMenu.SetActive(true);
    }
    public void QuitGame()
    {
        isQuit = true;
        QuitWarn.SetActive(true);
    }
    public void CloseMenu()
    {
        Menu.SetActive(false);
    }
    public void CloseOption()
    {
        OptionMenu.SetActive(false);
        DataManager.instance.nowSetting.MainVolume = Setting._MainVolume;
        DataManager.instance.nowSetting.EffectVolume = Setting._EffectVolume;
        DataManager.instance.nowSetting.IsFullScreen = Setting.isFullScreen;
        DataManager.instance.SaveSetting();

    }
    public void QuitYes()
    {
        if(isQuit==false)
            SceneManager.LoadScene("Opening");
        else 
            Application.Quit();
        

    }
    public void QuitNo()
    {
        QuitWarn.SetActive(false);
    }
}
