using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(disappear());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
