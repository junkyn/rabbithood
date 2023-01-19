using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.IO;
public class SavePoint : MonoBehaviour
{
    public GameObject SaveWindow;
    public TextMeshProUGUI[] slotText;
    bool[] savefile = new bool[3];
    public GameObject Success;
    public GameObject Check;
    private int slotnumber;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.instance.nowSlot = i;
                DataManager.instance.LoadData();
                slotText[i].text = DataManager.instance.nowPlayer.Name + " /// " + DataManager.instance.nowPlayer.nowTime;
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
        if(Input.GetKey(KeyCode.Escape))
            SaveWindow.SetActive(false);
    }
    public void Slot(int number)
    {
        if (File.Exists(DataManager.instance.path + $"{number}"))
        {
            Check.SetActive(true);
            slotnumber = number;
        
        }
        else if (File.Exists(DataManager.instance.path + $"{number}")==false) {
            DataManager.instance.nowSlot = number;
            Save(number);
            Success.SetActive(true); 
        }

    }

    public void Save(int slot)
    {
        DataManager.instance.nowPlayer.Name = PlayerStat.Name;
        DataManager.instance.nowPlayer.Stage = PlayerStat.Stage;
        DataManager.instance.nowPlayer.Skill_1 = PlayerStat.Skill_1;
        DataManager.instance.nowPlayer.Skill_2 = PlayerStat.Skill_2;
        DataManager.instance.nowPlayer.Skill_3 = PlayerStat.Skill_3;
        DataManager.instance.nowPlayer.nowTime = DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss tt"));
        DataManager.instance.SaveData(slot);
        slotText[slot].text = DataManager.instance.nowPlayer.Name + " /// " + DataManager.instance.nowPlayer.nowTime;

    }
    public void closeSave()
    {
        SaveCamp.isOpen = false;

        SaveWindow.SetActive(false);
    }
    public void CheckSave()
    {
        Success.SetActive(false);
    }
    public void YesChange()
    {
        Save(slotnumber);
        Check.SetActive(false);
    }
    public void NoChange()
    {
        Check.SetActive(false);
    }
}
