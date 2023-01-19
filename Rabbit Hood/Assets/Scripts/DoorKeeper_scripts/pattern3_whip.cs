using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattern3_whip : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Debug.Log("Whip Hit");
            Transform tr = col.transform;
            tr.position = tr.position + new Vector3(0, 1f, 0);
        }
    }
}
