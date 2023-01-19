using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal0 : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject player;
    public int portalnumber;
    AudioSource audioSource;
    public static bool isCanPortal = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Setting._EffectVolume;
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space) && isCanPortal)
        {
            Portal(portalnumber);
            isCanPortal = false;
            StartCoroutine(Portalcool());
        }
    }
    IEnumerator Portalcool()
    {
        yield return new WaitForSeconds(0.5f);
        isCanPortal = true;
    }
    void Portal(int number)
    {
        audioSource.Play();
        if (number == 0)
        {
            MainCamera.transform.position = new Vector3(0, -22, -10);

            player.transform.position = new Vector3(-7.5f, -25.8f, 0);
        }
        if (number == 1)
        {
            MainCamera.transform.position = new Vector3(-20, -22, -10);

            player.transform.position = new Vector3(-12.5f, -25.8f, 0);
        }
        if (number == 2)
        {
            MainCamera.transform.position = new Vector3(20, -22, -10);

            player.transform.position = new Vector3(12.5f, -25.8f, 0);

        }
        if (number == 3)
        {
            MainCamera.transform.position = new Vector3(0, -22, -10);

            player.transform.position = new Vector3(-7.5f, -19f, 0);

        }
        if (number == 4)
        {
            MainCamera.transform.position = new Vector3(40, -22, -10);

            player.transform.position = new Vector3(32.5f, -25.8f, 0);
        }
        if (number == 5)
        {
            MainCamera.transform.position = new Vector3(20, -22, -10);

            player.transform.position = new Vector3(27.5f, -25.8f, 0);
        }
        if (number == 6)
        {
            MainCamera.transform.position = new Vector3(60, -22, -10);

            player.transform.position = new Vector3(52.5f, -25.8f, 0);

        }
        if (number == 7)
        {
            MainCamera.transform.position = new Vector3(40, -22, -10);

            player.transform.position = new Vector3(47.5f, -25.8f, 0);

        }
        if (number == 8)
        {
            MainCamera.transform.position = new Vector3(80, -22, -10);

            player.transform.position = new Vector3(72.5f, -25.8f, 0);

        }
        if (number == 9)
        {
            MainCamera.transform.position = new Vector3(100, -22, -10);
            player.transform.position = new Vector3(92.5f, -25.8f, 0);

        }
        if (number == 10)
        {
            MainCamera.transform.position = new Vector3(0, -43, -10);
            player.transform.position = new Vector3(-7.5f, -47, 0);
        }
        if (number == 11)
        {
            MainCamera.transform.position = new Vector3(100, -22, -10);
            player.transform.position = new Vector3(107.5f, -25.8f, 0);
        }
        if (number == 12)
        {
            MainCamera.transform.position = new Vector3(20, -43, -10);
            player.transform.position = new Vector3(12.5f, -47f, 0);
        }
        if (number == 13)
        {
            MainCamera.transform.position = new Vector3(0, -43, -10);

            player.transform.position = new Vector3(7.5f, -47f, 0);

        }
        if (number == 14)
        {
            MainCamera.transform.position = new Vector3(40, -43, -10);

            player.transform.position = new Vector3(32.5f, -47f, 0);

        }
        if (number == 15)
        {
            MainCamera.transform.position = new Vector3(20, -43, -10);

            player.transform.position = new Vector3(27.5f, -47f, 0);
        }
        if (number == 16)
        {
            MainCamera.transform.position = new Vector3(60, -43, -10);

            player.transform.position = new Vector3(52.5f, -47f, 0);

        }
        if (number == 17)
        {
            MainCamera.transform.position = new Vector3(40, -43, -10);

            player.transform.position = new Vector3(47.5f, -47f, 0);

        }
        if (number == 18)
        {
            MainCamera.transform.position = new Vector3(80, -43, -10);

            player.transform.position = new Vector3(72.5f, -47f, 0);

        }
        if (number == 19)
        {
            MainCamera.transform.position = new Vector3(100, -43, -10);
            player.transform.position = new Vector3(92.5f, -47f, 0);

        }
        if (number == 20)
        {
            MainCamera.transform.position = new Vector3(125, -43, -10);
            player.transform.position = new Vector3(117f, -47f, 0);
        }


    }
}
