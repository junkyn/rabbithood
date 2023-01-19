using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watcher : MonoBehaviour
{
    private Transform player;
    private GameObject doorKeeper;
    SpriteRenderer sr;
    Rigidbody2D rigid;
    public GameObject portal;
    bool ismove = true;
    
    private void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        player = GameObject.Find("Player").transform;
        doorKeeper = GameObject.Find("DoorKeeper_main");
        sr = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();


    }
    void FixedUpdate()
    {
        if (ismove)
        {
            if (player.position.x > this.transform.position.x)
                sr.flipX = false;
            else
                sr.flipX = true;
        }
        if(Boss_DoorKeeper.isEnd==2)
        {
            StartCoroutine(run());
        }
        
    }

    IEnumerator run()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ismove = false;
        transform.parent = null;
        sr.sortingOrder++;
        sr.flipX = false;

        rigid.bodyType = RigidbodyType2D.Dynamic;
        yield return new WaitForSeconds(1.5f);
        rigid.AddForce(new Vector2(30f, 0f), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            portal.SetActive(true);
            Destroy(gameObject);

        }
    }


}

