using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvasCtrl : MonoBehaviour
{
    public GameObject Menu;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Menu.activeSelf == false&&Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
        }
        if(PlayerCtrl.Hp <= 0)
        {
            GameOver.gameObject.SetActive(true);
        }
    }
}
