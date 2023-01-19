using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public Animator animator;
    private GameObject player;
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetTag());
        animator.SetBool("isDestroy", false);
        player = FindObjectOfType<PlayerCtrl>().gameObject;
        moveSpeed = 0.5f;
        InvokeRepeating("ChasePlayer",2f,Time.deltaTime*2f);

    }

    // Update is called once per frame
    void ChasePlayer()
    {
            Vector2 gap = player.transform.position - transform.position;
            transform.position += (Vector3)gap * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Arrow")
        {
            animator.SetBool("isDestroy", true);
            gameObject.layer = 9;
            StartCoroutine(DestroyDelay());
        }
        if (gameObject.tag == "Monster")
        {
            animator.SetBool("isDestroy", true);
            StartCoroutine(DestroyDelay());
        }
    }

    IEnumerator DestroyDelay()
    {
        yield return 1f;
        Destroy(gameObject);
    }
    IEnumerator SetTag()
    {
        yield return new WaitForSeconds(1f);
        gameObject.tag = "Monster";
    }

}
