using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDSensor : MonoBehaviour
{
    public static bool Boss2start;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Boss2start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 70f && Boss2start == false && player.transform.position.y < -27 && player.transform.position.y >= -49 && PlayerStat.Stage < 4)
            Boss2start = true;
        else
            Boss2start = false;
    }
}
