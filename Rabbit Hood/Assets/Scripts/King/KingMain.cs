using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KingMain : MonoBehaviour
{
    private float MainPositionX;
    private float MainPositionY;
    public GameObject Player;
    public GameObject VerticalPrefab;
    Rigidbody2D rigid;
    SpriteRenderer rend;
    public GameObject Phase2;
    public GameObject Shadow1;
    public GameObject Shadow2;
    public GameObject Phase3;
    AudioSource audioSource;
    public AudioClip Pattern1;
    DateTime StartTime = DateTime.Now;
    DateTime NowTime = DateTime.Now;
    private float moveSpeed;
    private int isCanAttack = 2;
    public static int OpenPhase = 0;
    public GameObject Monster1Prefab;
    public GameObject _ThirdPhase;
    public GameObject Monster2Prefab;
    public Rigidbody2D playerRigid;
    public static int isEnd = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        moveSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCtrl.Hp < 0)
        {
            isEnd = 0;
            OpenPhase = 0;
            EventText.FinalBgmPhase = 0;
        }
        //audioSource.volume = Setting._EffectVolume;
        if (PlayerCtrl.isCanMove && Player.transform.position.x>111)
        {
            if(EventText.FinalBgmPhase == 1)
                EventText.FinalBgmPhase = 2;
            if(OpenPhase == 0||OpenPhase == 1)
            {
                if (isCanAttack == 2 && Player.transform.position.x >= transform.position.x)
                {
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    rend.flipX = true;
                }
                else if (isCanAttack == 2 && Player.transform.position.x < transform.position.x)
                {
                    this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                    rend.flipX = false;
                }
            }
            if(OpenPhase < 12)
            {
                switch (OpenPhase)
                {
                    case 0:
                        OpenPhase++;

                        StartCoroutine(WaitingTime());
                        break;
                    case 2:
                        OpenPhase++;
                        StartCoroutine(OnlyOpen());
                        break;
                    case 4:
                        OpenPhase++;
                        StartCoroutine(BeginGame());
                        break;
                    case 6:
                        OpenPhase++;

                        SecondPhase();
                        break;
                    case 8:
                        OpenPhase++;
                        StartCoroutine(ThirdPhase());
                        break;
                    case 10:
                        OpenPhase++;
                        StartCoroutine(Finish());
                        break;
                    default:
                        break;
                }
            }

        }
    }
    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(3f);
        OpenPhase++;

    }
    IEnumerator OnlyOpen()
    {
        float fadeCount = 1;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            rend.color = new Color(255, 255, 255, fadeCount);
        }
        rigid.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        MainPositionX = transform.position.x-8.5f;
        MainPositionY = transform.position.y;
        rend.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.5f);
        rigid.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.5f);
        rend.flipX = true;
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.5f);
        rend.flipX = false;
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
        fadeCount = 1;
        yield return new WaitForSeconds(0.5f);
        OpenPhase++;
    }
    IEnumerator BeginGame()
    {
        float fadeCount = 1;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            rend.color = new Color(255, 255, 255, fadeCount);
        }
        yield return new WaitForSeconds(1f);
        rend.color = new Color(255, 255, 255, 255);
        transform.position = new Vector2(Player.transform.position.x + 2f, Player.transform.position.y + 2f);
        rigid.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
        rigid.AddForce(Vector2.down * 4f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.8f);
        rigid.velocity = Vector2.zero;
        rend.flipX = true;
        rigid.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        fadeCount = 1;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            rend.color = new Color(255, 255, 255, fadeCount);
        }
        rigid.velocity = Vector2.zero;

        yield return new WaitForSeconds(0.5f);
        rend.color = new Color(255, 255, 255, 255);
        rend.flipX = false;
        transform.position = new Vector2(Player.transform.position.x + 0.8f, Player.transform.position.y + 4f);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rend.flipX = true;
        rigid.velocity = Vector2.zero;
        transform.position = new Vector2(Player.transform.position.x - 0.8f, Player.transform.position.y + 4f);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rigid.velocity = Vector2.zero;
        rend.flipX = false;
        transform.position = new Vector2(Player.transform.position.x + 0.8f, Player.transform.position.y + 4f);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rend.flipX = true;
        rigid.velocity = Vector2.zero;
        transform.position = new Vector2(Player.transform.position.x - 0.8f, Player.transform.position.y + 4f);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.5f);
        rend.flipX = false;
        VerticalSkill(MainPositionX-8);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        rend.flipX = true;
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);

        rigid.velocity = Vector2.zero;
        fadeCount = 1;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            rend.color = new Color(255, 255, 255, fadeCount);
        }
        rend.color = new Color(255, 255, 255, 255);
        transform.position = new Vector2(Player.transform.position.x - 2f, Player.transform.position.y + 2.3f);
        rigid.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);
        rigid.AddForce(Vector2.down * 4f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.8f);
        rigid.velocity = Vector2.zero;
        rend.flipX = false;
        rigid.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
        fadeCount = 1;
        while (fadeCount > 0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
            rend.color = new Color(255, 255, 255, fadeCount);
        }
        rigid.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(0.2f);
        rend.flipX = true;
        rend.color = new Color(255, 255, 255, 255);

        transform.position = new Vector2(Player.transform.position.x - 0.8f, Player.transform.position.y + 4f);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rend.flipX = false;
        rigid.velocity = Vector2.zero;
        transform.position = new Vector2(Player.transform.position.x + 0.8f, Player.transform.position.y + 4f);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rigid.velocity = Vector2.zero;
        rend.flipX = true;
        transform.position = new Vector2(Player.transform.position.x - 0.8f, Player.transform.position.y + 4f);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rend.flipX = false;
        rigid.velocity = Vector2.zero;
        transform.position = new Vector2(Player.transform.position.x + 0.8f, Player.transform.position.y + 4f);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.left * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.5F);
        rend.flipX = true;
        VerticalSkill(MainPositionX - 7f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.right * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        rend.flipX = false;
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 7f);
        yield return new WaitForSeconds(0.5f);
        VerticalSkill(MainPositionX - 8f);
        yield return new WaitForSeconds(1f);
        OpenPhase++;



    }
    void VerticalSkill(float VSspawn)
    {
        Instantiate(VerticalPrefab, new Vector3(VSspawn -= 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY+8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);
        Instantiate(VerticalPrefab, new Vector3(VSspawn += 2, MainPositionY + 8, 0), VerticalPrefab.transform.rotation, gameObject.transform);

    }



    void SecondPhase()
    {
        rigid.AddForce(Vector2.up * 30f, ForceMode2D.Impulse);
        this.transform.position = new Vector2(MainPositionX, MainPositionY+15);
        Phase2.SetActive(true);
    }

    IEnumerator ThirdPhase()
    {
        transform.position = new Vector2(MainPositionX, MainPositionY+8);
        rigid.AddForce(Vector2.down * 30f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        Shadow1.SetActive(true);
        Shadow2.SetActive(true);
        Phase3.SetActive(true);
        yield return new WaitForSeconds(2f);
        rigid.AddForce(Vector2.up * 5f);
        yield return new WaitForSeconds(0.5f);
        this.transform.position = new Vector2(MainPositionX, MainPositionY + 30);
        for (int i = 0; i<2; i++)
        {
            Instantiate(Monster1Prefab, new Vector2(MainPositionX-8, MainPositionY), transform.rotation, _ThirdPhase.transform);
            yield return new WaitForSeconds(4f);
            Instantiate(Monster1Prefab, new Vector2(MainPositionX, MainPositionY), transform.rotation, _ThirdPhase.transform);
            yield return new WaitForSeconds(4f);
            Instantiate(Monster1Prefab, new Vector2(MainPositionX+8, MainPositionY), transform.rotation, _ThirdPhase.transform);
            yield return new WaitForSeconds(4f);
        }
        for (int i = 0; i < 2; i++)
        {
            Instantiate(Monster2Prefab, new Vector2(MainPositionX-8, MainPositionY), transform.rotation, _ThirdPhase.transform);
            yield return new WaitForSeconds(4f);
            Instantiate(Monster1Prefab, new Vector2(MainPositionX, MainPositionY), transform.rotation, _ThirdPhase.transform);
            yield return new WaitForSeconds(4f);
            Instantiate(Monster2Prefab, new Vector2(MainPositionX+8, MainPositionY), transform.rotation, _ThirdPhase.transform);
            yield return new WaitForSeconds(4f);
        }
        Monster1Ctrl.PlayerSensor = true;
        Monster4Ctrl.PlayerSensor = true;
        yield return new WaitForSeconds(6f);
        transform.position = new Vector2(MainPositionX, MainPositionY + 8);
        rigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        _ThirdPhase.SetActive(false);
        Shadow1.SetActive(false);
        Shadow2.SetActive(false);
        Phase3.SetActive(false);
        OpenPhase++;
    }
    IEnumerator Finish()
    {
        playerRigid.velocity = Vector2.zero;
        playerRigid.bodyType = RigidbodyType2D.Kinematic;
        PlayerCtrl.isCanMove = false;
        while (Player.transform.position.y < gameObject.transform.position.y + 5f)
        {
            Player.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y + 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        EventText.FinalBgmPhase = 3;

    }
    
}
