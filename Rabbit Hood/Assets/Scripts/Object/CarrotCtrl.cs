using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCtrl : MonoBehaviour
{
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        StartCoroutine(Animation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Animation()
    {
        float trcount = 0;
        float tempY= tr.position.y;
        while (true)
        {
            while (trcount < 0.1f)
            {
                trcount += 0.001f;
                tr.position = new Vector3(tr.position.x, tempY + trcount, tr.position.z);
                yield return new WaitForSeconds(0.005f);
            }
            while(trcount > 0f)
            {
                trcount -= 0.001f;
                tr.position = new Vector3(tr.position.x, tempY + trcount, tr.position.z);
                yield return new WaitForSeconds(0.005f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Heal();
        }
    }

    void Heal()
    {
        if (PlayerCtrl.Hp < PlayerStat.maxHP)
            PlayerCtrl.Hp++;
        Destroy(gameObject);
    }
}
