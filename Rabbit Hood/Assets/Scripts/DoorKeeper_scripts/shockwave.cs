using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shockwave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player" || obj.tag == "Wall")
            Destroy(gameObject);
    }
}
