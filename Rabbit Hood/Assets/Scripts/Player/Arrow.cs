using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform tr;
    public Rigidbody2D rigid;
    public SpriteRenderer rend;
    private GameObject player;
    public bool Damaged = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>().gameObject;
        if (player.transform.position.x<tr.position.x)
        {
            transform.Rotate(0, 0, -8);
            rend.flipX = false;
            rigid.AddForce(Vector2.right * PlayerStat.arrowSpeed, ForceMode2D.Impulse);
            rigid.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
        }
        if (player.transform.position.x > tr.position.x)
        {
            transform.Rotate(0, 0, 8);
            rend.flipX = true;
            rigid.AddForce(Vector2.left * PlayerStat.arrowSpeed, ForceMode2D.Impulse);
            rigid.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rend.flipX == false)
            transform.right = GetComponent<Rigidbody2D>().velocity;
        else if (rend.flipX == true)
            transform.right = -(GetComponent<Rigidbody2D>().velocity);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player" && col.tag != "Boss_Skill")
            Destroy(this.gameObject);
    }
}
