using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeeper_projectile : MonoBehaviour
{
    float timer = 0.0f;
    Rigidbody2D rigid;
    private GameObject DoorKeeper;
    void Start()
    {
        DoorKeeper = FindObjectOfType<Boss_DoorKeeper>().gameObject;
    }
    void Update()
    {
        if(DoorKeeper == null)
            Destroy(gameObject);
        timer += Time.deltaTime;
        if (timer >= 5.0f)
            Destroy(gameObject);   
        
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
            Destroy(gameObject);
    }

}
