using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattern3_warning : MonoBehaviour
{
    SpriteRenderer sr;
    
    void Start()
    {
        transform.parent = GameObject.Find("DoorKeeper_main").transform;

        sr = GetComponent<SpriteRenderer>();

        sr.color = new Color(1f, 0f, 0f, 0.5f);
        StartCoroutine(coloring());

    }

    IEnumerator coloring()
    {
        float trans = 0.0f;

        while (trans <= 0.6f)
        {
            sr.color = new Color(1f, 0f, 0f, trans);
            yield return new WaitForSeconds(0.05f);
            trans += 0.05f;
        }

        Destroy(gameObject);
    }
}
