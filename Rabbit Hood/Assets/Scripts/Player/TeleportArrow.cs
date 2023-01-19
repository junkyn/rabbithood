using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportArrow : MonoBehaviour
{
    public Transform tr;
    public static float arrow_x, arrow_y;
    public Rigidbody2D rigid;
    public SpriteRenderer rend;
    private GameObject player;
    public static bool Arrived = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCtrl>().gameObject;
        if (player.transform.position.x < tr.position.x)
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
        if (rend.flipX == false)
            transform.right = GetComponent<Rigidbody2D>().velocity;
        else if (rend.flipX == true)
            transform.right = -(GetComponent<Rigidbody2D>().velocity);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall" || col.tag == "Floor") {
            Arrived = true;
            arrow_x = tr.transform.position.x;
            arrow_y = tr.transform.position.y;
            teleport();
            }
    }
    IEnumerator teleport()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
