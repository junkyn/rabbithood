using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    Vector2 origin_pos = new Vector2(-7f, 3f);
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Transform tr = col.GetComponent<Transform>();
            tr = tr.parent;

            tr.position = origin_pos;
        }
    }
}
