using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKSensor : MonoBehaviour
{
    public GameObject DoorKeeper;
    public GameObject Watcher;
    public static bool Boss1start;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Boss1start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 70f && Boss1start == false && player.transform.position.x < 89 && player.transform.position.y > -27 && PlayerStat.Stage < 2)
            Boss1start = true;

        else
            Boss1start = false;

    }

}
