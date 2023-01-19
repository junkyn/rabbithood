using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_1 : MonoBehaviour
{
    // Start is called before the first frame update0
    public GameObject portal;
    public static bool isclear = false;
    public SpriteRenderer frame;

    

    // Update is called once per frame
    void Update()
    {
        if (frame.color == new Color(0.3882353f, 0.3176471f, 0.2745098f, 0))
            isclear = true;
        if (isclear)
        {
            portal.SetActive(true);
            isclear = false;
        }
    }
}
