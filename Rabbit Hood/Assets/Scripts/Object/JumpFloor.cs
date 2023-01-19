using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFloor : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= transform.position.y+1)
        {
            gameObject.layer = 0;
        }
        else if(player.transform.position.y < transform.position.y)
        {
            gameObject.layer = 12;
        }
    }
}
