using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBgm : MonoBehaviour
{
    public static AudioSource audioSource;
    public AudioClip GameOver;
    public AudioClip Boss1;
    public AudioClip Clear;
    public AudioClip Boss2;
    public GameObject Player;
    public AudioClip BeforeCastle;
    public AudioClip forest;
    public AudioClip castle;
    public AudioClip Boss3;
    public AudioClip Ending;
    public AudioClip Boss4;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Setting._MainVolume;
        if (PlayerCtrl.Hp <= 0 && audioSource.clip != GameOver)
        {
            audioSource.clip = GameOver;
            audioSource.loop = false;
            audioSource.Play();
        }
        if (PlayerCtrl.Hp > 0)
        {
            if (Player.transform.position.x <= 69 && Player.transform.position.x >= -9 && Player.transform.position.y >= -27 && audioSource.clip != forest)
            {
                audioSource.clip = forest;
                audioSource.loop = true;
                audioSource.Play();
            }
            if (Player.transform.position.x > 89 && Player.transform.position.y >= -27 && audioSource.clip != BeforeCastle)
            {
                audioSource.clip = BeforeCastle;
                audioSource.loop = true;
                audioSource.Play();
            }
            if (DKSensor.Boss1start && EventText.DKAppear == false && audioSource.clip != null)
            {
                audioSource.clip = null;
                audioSource.loop = false;
                audioSource.Play();
            }
            if (EventText.DKAppear && audioSource.clip != Boss1 && Boss_DoorKeeper.isEnd == 0 && PlayerStat.Stage <= 1)
            {
                audioSource.clip = Boss1;
                audioSource.loop = true;
                audioSource.Play();
            }
            if (Player.transform.position.x <= 69 && Player.transform.position.x >= -9 && Player.transform.position.y >= -49 && Player.transform.position.y < -27 && audioSource.clip != castle)
            {
                audioSource.clip = castle;
                audioSource.loop = true;
                audioSource.Play();
            }
            if (Player.transform.position.x<116f&& Player.transform.position.x > 89 && Player.transform.position.y < -27 && Player.transform.position.y >= -49 && audioSource.clip != castle)
            {
                audioSource.clip = castle;
                audioSource.loop = true;
                audioSource.Play();
            }

            if (Boss_DoorKeeper.isEnd == 2 && audioSource.clip != Clear&&Player.transform.position.x<89&&Player.transform.position.y>-27)
            {
                audioSource.clip = Clear;
                audioSource.loop = false;
                audioSource.Play();
            }
            if (GDSensor.Boss2start && EventText.GDAppear == false && audioSource.clip != null)
            {
                audioSource.clip = null;
                audioSource.loop = false;
                audioSource.Play();
            }

            if (EventText.GDAppear && audioSource.clip != Boss2 && Guardian_pattern.isEnd == 0 && PlayerStat.Stage <= 3)
            {
                audioSource.clip = Boss2;
                audioSource.loop = true;
                audioSource.Play();
            }
            if (Guardian_pattern.isEnd == 2 && audioSource.clip != Clear && Player.transform.position.x < 89 && Player.transform.position.y < -27&&Player.transform.position.y>=-49)
            {
                audioSource.clip = Clear;
                audioSource.loop = false;
                audioSource.Play();
            }
            if(WWSensor.Boss3Start && EventText.WWAppear == false && audioSource.clip != null && Boss_WhiteWolfCtrl.isEnd < 3&& EventText.FinalBgmPhase == 0)
            {
                audioSource.clip = null;
                audioSource.loop = false;
                audioSource.Play();
            }
            if(EventText.WWAppear && audioSource.clip != Boss3 && Boss_WhiteWolfCtrl.isEnd < 3)
            {
                audioSource.clip = Boss3;
                audioSource.loop = true;
                audioSource.Play();

            }
            if(EventText.FinalBgmPhase == 1 && audioSource.clip != Ending)
            {
                audioSource.clip = Ending;
                audioSource.loop = true;
                audioSource.Play();
            }
            if (EventText.FinalBgmPhase == 2 && audioSource.clip != Boss4)
            {
                audioSource.clip = Boss4;
                audioSource.loop = true;
                audioSource.Play();
            }
            if(EventText.FinalBgmPhase == 4 && audioSource.clip != Ending)
            {
                audioSource.clip = Ending;
                audioSource.loop = true;
                audioSource.Play();
            }
        }

    }
}
