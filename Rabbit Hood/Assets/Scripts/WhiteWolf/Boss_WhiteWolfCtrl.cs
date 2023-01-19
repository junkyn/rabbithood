using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Boss_WhiteWolfCtrl : MonoBehaviour
{
    public GameObject player; //플레이어
    private float moveSpeed;
    private int isCanAttack; // 0 = 패턴가능 1 = 패턴 진행 2 = 쿨타임
    public Rigidbody2D rigid;
    public SpriteRenderer rend;
    public GameObject claw;
    public SpriteRenderer claw_rend;
    public GameObject EnergyBall;
    private int PatternNum, temp;
    private float Hp;
    private float maxHp;
    private float cooltime;
    private int phase=0;
    private bool isAnimation = false;
    public AudioClip AudioPattern1;
    public AudioClip AudioPattern2;
    public AudioClip AudioPattern3;
    private bool isCanDamage;
    public GameObject hpbar;
    AudioSource audioSource;
    public static int isEnd = 0;

    // Start is called before the first frame update
    void Start()
    {
        isEnd = 0;
        maxHp = 40;
        Hp = maxHp;
        cooltime = 5f;
        temp = 0;
        moveSpeed = 1.3f;
        isCanAttack = 2;
        rend = GetComponent<SpriteRenderer>();
        StartCoroutine(Cooltime());
        audioSource = GetComponent<AudioSource>();
        isCanDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerCtrl.Hp <= 0)
        {
            isEnd = 0;
            Hp = maxHp;
        }

        audioSource.volume = Setting._EffectVolume;

        if (PlayerCtrl.isCanMove&&WWSensor.Boss3Start)
        {
            hpbar.SetActive(true);
            BossHp.value = (Hp / maxHp)*100;
            if (isCanAttack == 2 && player.transform.position.x > transform.position.x)
            {
                this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                rend.flipX = true;
            }
            else if (isCanAttack == 2 && player.transform.position.x < transform.position.x)
            {
                this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                rend.flipX = false;
            }
            if (isCanAttack == 0 && isAnimation == false)
                Pattern();
            if (Hp < maxHp * 0.5f && isEnd == 0)
                isEnd = 1;
            if (Hp <= 0)
            {
                hpbar.SetActive(false);
                isEnd = 2;
                Debug.Log("Clear");
            }
            if(isEnd ==3)
                Destroy(gameObject);
        }
    }

    private void Pattern()
    {
        PatternNum = Random.Range(0, 3);
        while (temp == PatternNum)
            PatternNum = Random.Range(0, 3);
        temp = PatternNum;
        isCanAttack = 1;

        if (PatternNum == 0)
        {
            StartCoroutine(Pattern1());
        }
        else if (PatternNum == 1)
        {
            StartCoroutine(Pattern2());
        }
        else if (PatternNum == 2)
        {
            StartCoroutine(Pattern3());
        }


    }
    IEnumerator Pattern1()
    {
        Vector2 temp = player.transform.position;
        yield return new WaitForSeconds(0.65f);
        PlaySound("PATTERN1");
        yield return new WaitForSeconds(1.3f);
        rigid.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        if (temp.x > transform.position.x)
        {
            rigid.AddForce(Vector2.right * 8f, ForceMode2D.Impulse);
        }
        else
        {
            rigid.AddForce(Vector2.left * 8f, ForceMode2D.Impulse);
        }
        StartCoroutine(Cooltime());
        isCanAttack = 2;
    }
    IEnumerator Pattern2()
    {
        rigid.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        PlaySound("PATTERN2");
        yield return new WaitForSeconds(0.6f);
        if (player.transform.position.x < transform.position.x)
        {
            claw.transform.position = new Vector3(transform.position.x - 0.6f, transform.position.y, transform.position.z);
            claw_rend.flipX = false;
            rend.flipX = false;
            rigid.AddForce(Vector2.left * 12f, ForceMode2D.Impulse);
        }
        else if (player.transform.position.x > transform.position.x)
        {
            claw.transform.position = new Vector3(transform.position.x + 0.6f, transform.position.y, transform.position.z);
            claw_rend.flipX = true;
            rend.flipX = true;
            rigid.AddForce(Vector2.right * 12f, ForceMode2D.Impulse);
        }
        claw.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            claw_rend.flipY = true;
            yield return new WaitForSeconds(0.1f);
            claw_rend.flipY = false;
        }
        claw.SetActive(false);
        StartCoroutine(Cooltime());
        isCanAttack = 2;
    }
    IEnumerator Pattern3()
    {
        PlaySound("PATTERN3");
        Instantiate(EnergyBall, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity, transform);
        Instantiate(EnergyBall, new Vector3(transform.position.x - 1f, transform.position.y + 0.7f, transform.position.z), Quaternion.identity, transform);
        Instantiate(EnergyBall, new Vector3(transform.position.x + 1f, transform.position.y + 0.7f, transform.position.z), Quaternion.identity, transform);
        yield return new WaitForSeconds(2f);
        isCanAttack = 2;
        StartCoroutine(Cooltime());
    }

    IEnumerator Cooltime()
    {
        yield return new WaitForSeconds(cooltime);
        isCanAttack = 0;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            isCanAttack = 2;
            claw.SetActive(false);
        }
        if (col.tag == "Arrow")
        {
            if (col.GetComponent<Arrow>().Damaged == false)
            {
                Hp = Hp - PlayerStat.attack;
                col.GetComponent<Arrow>().Damaged = true;
            }
        }

    }
    void PlaySound(string action)
    {
        switch (action)
        {
            case "PATTERN1":
                audioSource.clip = AudioPattern1;
                break;
            case "PATTERN2":
                audioSource.clip = AudioPattern2;
                break;
            case "PATTERN3":
                audioSource.clip = AudioPattern3;
                break;
        }
        audioSource.Play();


    }
}
