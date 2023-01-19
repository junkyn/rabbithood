using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class PlayerData
{
    public string Name;
    public int Stage;
    public string Skill_1;
    public string Skill_2;
    public string Skill_3;
    public string nowTime;

}
public class SettingData
{
    public bool IsFullScreen;
    public float MainVolume;
    public float EffectVolume;
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public PlayerData nowPlayer = new PlayerData();
    public SettingData nowSetting = new SettingData();
    public string path;

    public int nowSlot;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/";
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SaveData(int i)
    {
        nowSlot = i;
        string data = JsonUtility.ToJson(nowPlayer);

        File.WriteAllText(path + nowSlot.ToString(), data);
    }
    public void SaveSetting()
    {
        string setting = JsonUtility.ToJson(nowSetting);
        File.WriteAllText(path + "Setting", setting);
    }
    public void LoadSetting()
    {
        string setting = File.ReadAllText(path + "Setting");
        nowSetting = JsonUtility.FromJson<SettingData>(setting);
    }
    public void LoadData()
    {
        string data = File.ReadAllText(path +nowSlot.ToString());
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }
    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
