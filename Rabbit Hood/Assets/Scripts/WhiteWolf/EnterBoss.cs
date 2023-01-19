using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterBoss : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerTxt;
    public GameObject WolfTxt;
    public GameObject Txt;
    public GameObject Boss;
    public GameObject WhiteWolf;
    public TextMeshProUGUI Scripttxt;
    private bool isEnter = false;
    private int phase = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            if (Input.GetKeyUp(KeyCode.Space))
                phase++;
            switch (phase)
            {
                case 0:
                    PlayerCtrl.isCanAttack = false;

                    PlayerTxt.SetActive(true);
                    Txt.SetActive(true);
                    Scripttxt.text = "하울?...";
                    break;
                case 1:
                    Scripttxt.text = "많이 다쳤구나 어서 돌아가자";
                    break;
                case 2:
                    PlayerTxt.SetActive(false);
                    WolfTxt.SetActive(true);
                    Scripttxt.text = "...";
                    break;
                case 3:
                    PlayerCtrl.isCanAttack = true;
                    WolfTxt.SetActive(false);
                    Txt.SetActive(false);
                    Boss.SetActive(true);
                    Destroy(WhiteWolf.gameObject);
                    Destroy(gameObject);
                    break;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
            isEnter = true;
    }
}
