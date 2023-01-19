using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fake_portal : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer fakeportal;
    public GameObject itself;
    public bool disappear = false;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            disappear = true;
            StartCoroutine(Fadeout());
        }
    }
    IEnumerator Fadeout()
    {
        float fadecount = 1f;
        while (fadecount > 0f)
        {
            fadecount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fakeportal.color = new Color(0.3137255f, 0.5882353f, 1f, fadecount);
        }
        itself.SetActive(false);
    }

}
