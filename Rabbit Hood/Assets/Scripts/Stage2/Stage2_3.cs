using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_3 : MonoBehaviour
{
    // Start is called before the first frame update0
    public GameObject portal;
    public GameObject Stonerain;
    public GameObject phase_1;
    public GameObject phase_2;
    public GameObject phase_3;
    public GameObject path;
    public static bool isclear = false;
    public GameObject fake_portal;
    public SpriteRenderer frame;


    // Update is called once per frame
    void Update()
    {
        if (fake_portal.GetComponent<fake_portal>().disappear == true)
        {
            StartCoroutine(phase());
            fake_portal.GetComponent<fake_portal>().disappear = false;
        }
        if (frame.color == new Color(0.3882353f, 0.3176471f, 0.2745098f, 0))
            isclear = true;
        if (isclear)
        {
            portal.SetActive(true);
            isclear = false;
        }
    }

    IEnumerator phase()
    {
        Stonerain.SetActive(true);
        yield return new WaitForSeconds(2f);
        phase_1.SetActive(true);
        yield return new WaitForSeconds(10f);
        phase_2.SetActive(true);
        yield return new WaitForSeconds(10f);
        phase_3.SetActive(true);
        yield return new WaitForSeconds(10f);
        yield return new WaitForSeconds(2f);
        Stonerain.SetActive(false);
        yield return new WaitForSeconds(1f);
        path.SetActive(true);
    }




}
