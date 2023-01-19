using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian_pattern : MonoBehaviour
{
    private Transform tr;
    private Rigidbody2D rigid;
    private bool Shield_bool;
    public GameObject Shield1, Shield2, Attack, Shout;
    AudioSource audioSource;
    public AudioClip AudioPattern1;
    public AudioClip AudioPattern2;
    public AudioClip AudioPattern3_1;
    public AudioClip AudioPattern3_2;
    public AudioClip AudioPattern4;
    public AudioClip AudioPattern5;
    public SpriteRenderer rend;
    private int isCanAttack;
    private float cooltime;
    private int PatternNum;
    private bool isCanDamage;
    public GameObject player;
    private float moveSpeed;
    private int temp;
    public SpriteRenderer Attack_rend;
    public SpriteRenderer Shout_rend;
    public SpriteRenderer Shield1_rend;
    public SpriteRenderer Shield2_rend;
    const float MaxHp = 100;
    private float hp = MaxHp;
    private float pattern_movespeed;
    public static int isEnd = 0;
    public GameObject hpbar;

    
    // Start is called before the first frame update
    void Start()
    {
        hpbar.SetActive(true);
        tr = this.GetComponent<Transform>();
        rigid = this.GetComponent<Rigidbody2D>();
        Shield_bool = false;

        isCanAttack = 2;
        rend = GetComponent<SpriteRenderer>();
        cooltime = 5f;
        temp = 0;
        StartCoroutine(Cooltime());
        isCanDamage = true;
        moveSpeed = 1.6f;
        pattern_movespeed = 0.01f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    //보스 패턴 만들기 용,
    //임의로 문자 누르면 패턴하게 해놨음
    // 0 = 패턴가능 1 = 패턴 진행 2 = 쿨타임
    void Update()
    {
        BossHp.value = hp / MaxHp;
        if (PlayerCtrl.Hp <= 0)
        {
            isEnd = 0;
            hp = 200;
        }

        audioSource.volume = Setting._EffectVolume;
        if (PlayerCtrl.isCanMove&&GDSensor.Boss2start)
        {
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
            if (isCanAttack == 0)
                Pattern();
            if (hp <= 0)
            {
                hpbar.SetActive(false);
                isEnd = 1;
            }



            //돌진 패턴 (좌측은 Q, 우측은 W)



            //방패 E (연속으로 공격받았을때 자동으로 방패 들어올리는 용) - 패시브
           


            //공격 패턴 R
            // 2연속 기본 공격


            //방패 패턴 (방패후 넉백)


            //외침 패턴 (기절) Y



        }

    }

    private void Pattern()
    {
        PatternNum = Random.Range(0, 6);

        while (temp == PatternNum)
            PatternNum = Random.Range(0, 6);
        temp = PatternNum;
        isCanAttack = 1;

        if (PatternNum == 0)
            StartCoroutine(Pattern1());
        else if (PatternNum == 1)
            StartCoroutine(Pattern2());
        else if (PatternNum == 2)
            StartCoroutine(Pattern3());
        else if (PatternNum == 3)
            StartCoroutine(Pattern4());
        else if (PatternNum == 4 || PatternNum == 5)
            StartCoroutine(Pattern5());
    }
    IEnumerator Pattern1()
    {
        Vector2 temp = player.transform.position;
        yield return new WaitForSeconds(1f);
        PlaySound("PATTERN1");
        if (temp.x>transform.position.x)
        rigid.AddForce(new Vector3(6f, 0f, 0f), ForceMode2D.Impulse);
        else
        rigid.AddForce(new Vector3(-6f, 0f, 0f), ForceMode2D.Impulse);
        StartCoroutine(Cooltime());
        isCanAttack = 2;
    }
    IEnumerator Pattern2()
    {
        if(player.transform.position.x<transform.position.x)
        {
            Attack.transform.position = new Vector3(transform.position.x - 0.6f, transform.position.y+0.2f, transform.position.z);
            Attack_rend.flipX=false;
            rend.flipX = false;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            Attack.transform.position = new Vector3(transform.position.x + 0.6f, transform.position.y+ 0.2f, transform.position.z);
            Attack_rend.flipX = true;
            rend.flipX = true;
        }
        PlaySound("PATTERN2");
        Vector2 gap = player.transform.position - this.transform.position;
        this.transform.position += (Vector3)gap * pattern_movespeed * Time.deltaTime;
        Attack.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Attack.SetActive(false);
        this.transform.position += (Vector3)gap * pattern_movespeed * Time.deltaTime;
        yield return new WaitForSeconds(0.2f);
        Attack.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        Attack.SetActive(false);

        StartCoroutine(Cooltime());
        isCanAttack = 2;
    }
    IEnumerator Pattern3()
    {
        if (player.transform.position.x < transform.position.x)
        {
            Shield1.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
            Shield2.transform.position = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
            Shield1_rend.flipX = false;
            Shield2_rend.flipX = false;
            rend.flipX = false;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            Shield1.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
            Shield2.transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
            Shield1_rend.flipX = true;
            Shield2_rend.flipX = true;
            rend.flipX = true;
        }
        Shield1.SetActive(true);
        PlaySound("PATTERN5");
        yield return new WaitForSeconds(0.5f);
        PlaySound("PATTERN3_1");
        yield return new WaitForSeconds(2.5f);
        PlaySound("PATTERN3_2");
        Shield1.SetActive(false);
        Shield2.SetActive(true);
        Vector2 gap = player.transform.position - this.transform.position;
        this.transform.position += (Vector3)gap * pattern_movespeed * Time.deltaTime;
        yield return new WaitForSeconds(2f);
        Shield2.SetActive(false);

        StartCoroutine(Cooltime());
        isCanAttack = 2;
    }
    IEnumerator Pattern4()
    {
        int isflip = 0;
        if (player.transform.position.x < transform.position.x)
        {
            Shout.transform.position = new Vector3(transform.position.x - 2f, Shout.transform.position.y, transform.position.z);
            Shout_rend.flipX = false;
            rend.flipX = false;
            isflip = 1;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            Shout.transform.position = new Vector3(transform.position.x + 2f, Shout.transform.position.y, transform.position.z);
            Shout_rend.flipX = true;
            rend.flipX = true;
            isflip = -1;
        }
        yield return new WaitForSeconds(1.5f);
        Vector2 gap = player.transform.position - this.transform.position;
        this.transform.position += (Vector3)gap * pattern_movespeed * Time.deltaTime;
        PlaySound("PATTERN4");
        Shout.SetActive(true);
        StartCoroutine(ShoutingScale());
        StartCoroutine(ShoutingPos(isflip));
        yield return new WaitForSeconds(3f);
        Shout.transform.localScale = new Vector3(0, Shout.transform.localScale.y, 0);
        Shout.transform.position = new Vector3(transform.position.x, Shout.transform.position.y, 0);
        Shout.SetActive(false);
        StartCoroutine(Cooltime());
        isCanAttack = 2;
    }
    IEnumerator ShoutingScale()
    {
        float ScaleCount = 0;
        while (Shout.transform.localScale.x < 0.8)
        {
            ScaleCount += 0.03f;
            Shout.transform.localScale = new Vector3(ScaleCount, Shout.transform.localScale.y, Shout.transform.localScale.z);
            yield return new WaitForSeconds(0.001f);

        }
    }
    IEnumerator ShoutingPos(int i)
    {
        float PositionCount = 0;
        while (PositionCount > -1.2 && PositionCount<1.2)
        {
            PositionCount -= 0.05f*i;
            Shout.transform.position = new Vector3(transform.position.x+PositionCount, Shout.transform.position.y, 0);
            yield return new WaitForSeconds(0.001f);

        }
    }
    IEnumerator Pattern5()
    {
        if (player.transform.position.x < transform.position.x)
        {
            Shield1.transform.position = new Vector3(transform.position.x - 0.7f, transform.position.y, transform.position.z);
            Shield1_rend.flipX = true;
            rend.flipX = false;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            Shield1.transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, transform.position.z);
            Shield1_rend.flipX = false;
            rend.flipX = true;
        }
        PlaySound("PATTERN5");
        Shield1.SetActive(true);
        yield return new WaitForSeconds(2f);
        Shield1.SetActive(false);

        StartCoroutine(Cooltime());
        isCanAttack = 2;
    }
    IEnumerator Cooltime()
    {
        yield return new WaitForSeconds(cooltime);
        isCanAttack = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Arrow")
        {
            if (col.GetComponent<Arrow>().Damaged == false)
            {
                hp = hp - PlayerStat.attack;
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
            case "PATTERN3_1":
                audioSource.clip = AudioPattern3_1;
                break;
            case "PATTERN3_2":
                audioSource.clip = AudioPattern3_2;
                break;

            case "PATTERN4":
                audioSource.clip = AudioPattern4;
                break;
            case "PATTERN5":
                audioSource.clip = AudioPattern5;
                break;

        }
        audioSource.Play();
    }

}
