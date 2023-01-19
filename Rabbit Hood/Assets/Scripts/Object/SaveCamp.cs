using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCamp : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject SaveSlot;
    public int SavePoint;
    public static bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Setting._EffectVolume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.mute = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        audioSource.mute = true;
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"&& Input.GetKey(KeyCode.Space))
        {
            isOpen = true;
            PlayerStat.Stage = SavePoint;
            SaveSlot.SetActive(true);
            PlayerCtrl.Hp = PlayerStat.maxHP;
        }
    }
}
