using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2_3_puz : MonoBehaviour
{
    public SpriteRenderer column1;
    public SpriteRenderer column2;
    public SpriteRenderer column3;
    public SpriteRenderer column4;
    private bool First;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow" && First)
        {
            column1.color = new Color(255, 0, 0, 255);
            column3.color = new Color(255, 0, 0, 255);
            First = false;
        }
        else if (collision.tag == "Arrow" && First)
        {
            column1.color = new Color(255, 255, 255, 255);
            column3.color = new Color(255, 255, 255, 255);
            First = false;
        }
    }
}

