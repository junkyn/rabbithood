using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour
{
    private GameObject player;
    private float moveSpeed;
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerCtrl>().gameObject;
        moveSpeed = 4f;
        if (player.transform.position.x - transform.position.x >= 0)
        {
            rigid.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
        }
        if (player.transform.position.x - transform.position.x < 0)
        {
            rigid.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);
        }

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Arrow")
        {
            Destroy(gameObject);
        }
        if (gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
        if(gameObject.tag=="Wall")
            Destroy(gameObject); 
    }


}

