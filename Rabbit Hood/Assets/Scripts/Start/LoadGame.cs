using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class LoadGame : MonoBehaviour
{
    public TextMeshProUGUI[] slotText;
    bool[] savefile = new bool[3];
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            if(File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.Name + " /// "+ DataManager.instance.nowPlayer.nowTime;
            }
            else
            {
                slotText[i].text = "비어있음";
            }

        }
        DataManager.instance.DataClear();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slot(int number)
    {
        DataManager.instance.nowSlot = number;
        if (savefile[number])
        {
            DataManager.instance.LoadData();
            GoGame();

        }

    }
    public void GoGame()
    {
        SceneManager.LoadScene("Main");
    }
}
