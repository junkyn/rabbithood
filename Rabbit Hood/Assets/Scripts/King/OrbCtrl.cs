using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCtrl : MonoBehaviour
{
    private int hp = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            Phase2.OrbStack--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Arrow")
            hp--;
    }
    // Update is called once per frame
}
