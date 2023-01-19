using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    public GameObject WhiteWolf;
    public GameObject King;
    public GameObject player;
    public GameObject MainCamera;
    PlayerStat playerStat;
    // Start is called before the first frame update
    void Start()
    {
        playerStat = new PlayerStat();
        PlayerStat.Name = DataManager.instance.nowPlayer.Name;
        playerStat.statupdate(DataManager.instance.nowPlayer.Skill_1);
        playerStat.statupdate( DataManager.instance.nowPlayer.Skill_2);
        playerStat.statupdate(DataManager.instance.nowPlayer.Skill_3);
        PlayerStat.Stage = DataManager.instance.nowPlayer.Stage;
        if(PlayerStat.Stage == 0)
        {
            player.transform.position = new Vector3(-28, -25.8f, 0);
            MainCamera.transform.position = new Vector3(-20, -22, -10);

        }
        if (PlayerStat.Stage == 1)
        {
            player.transform.position = new Vector3(56, -25.8f, 0);
            MainCamera.transform.position = new Vector3(60, -22, -10);

        }
        if (PlayerStat.Stage == 2)
        {
            player.transform.position = new Vector3(96, -25.8f, 0);
            MainCamera.transform.position = new Vector3(100, -22, -10);
        }
        if (PlayerStat.Stage == 3)
        {
            player.transform.position = new Vector3(56, -47f, 0);
            MainCamera.transform.position = new Vector3(60, -43, -10);
        }
        if(PlayerStat.Stage == 4)
        {
            player.transform.position = new Vector3(96, -47f, 0);
            MainCamera.transform.position = new Vector3(100, -43, -10);
        }
        if(PlayerStat.Stage == 5)
        {
            player.transform.position = new Vector3(96, -47f, 0);
            MainCamera.transform.position = new Vector3(100, -43, -10);
            WhiteWolf.SetActive(false);
            King.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
