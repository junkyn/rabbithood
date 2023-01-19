using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheck : MonoBehaviour
{
    GameObject portal;
    private void Start()
    {
        portal = GameObject.Find("portal1_2_2");
        portal.SetActive(false);
    }
    private void Update()
    {
        if (transform.childCount == 0)
        {
            portal.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
