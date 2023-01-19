using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame2_1 : MonoBehaviour
{
    public SpriteRenderer square;
    public GameObject path1;
    public GameObject path2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D col)
    {


        if (col.tag == "Arrow")
        {
            StartCoroutine(Fadeout());
        }
    }
    IEnumerator Fadeout()
    {
        float fadecount = 1;
        while(fadecount >0f)
        {
            fadecount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            square.color = new Color(0.3882353f, 0.3176471f, 0.2745098f, fadecount);
        }

        path1.SetActive(false);
        path2.SetActive(true);
    }


}
