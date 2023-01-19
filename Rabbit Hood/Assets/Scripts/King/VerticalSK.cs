using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalSK : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    IEnumerator DOIT()
    {
        yield return new WaitForSeconds(1f);
        rigid.AddForce(Vector2.down * 30f, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" || collision.tag == "Floor")
        {
            Destroy(gameObject);
        }
    }
}
