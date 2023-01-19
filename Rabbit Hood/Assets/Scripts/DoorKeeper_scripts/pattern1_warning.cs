using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattern1_warning : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sr;
    void Start()
    {
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
            yield return new WaitForSeconds(0.1f);
            trans += 0.05f;
        }

        Destroy(gameObject);
    }
}
