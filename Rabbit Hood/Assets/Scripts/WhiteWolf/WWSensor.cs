using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WWSensor : MonoBehaviour
{
    public static bool Boss3Start;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Boss3Start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > 116f && Boss3Start == false && player.transform.position.y < -27f && PlayerStat.Stage <= 5)
            Boss3Start = true;
        else
            Boss3Start = false;
    }
}
