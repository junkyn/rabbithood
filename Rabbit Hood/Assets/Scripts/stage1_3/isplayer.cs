using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class isplayer : MonoBehaviour
{
    GameObject[] obstacles = new GameObject[2];
    private void Start()
    {
        obstacles[0] = GameObject.Find("approaching_1");
        obstacles[1] = GameObject.Find("approaching_2");
        obstacles[0].SetActive(false);
        obstacles[1].SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            obstacles[0].SetActive(true);
            obstacles[1].SetActive(true);
        }
    }
}
