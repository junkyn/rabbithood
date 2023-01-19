using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_DoorKeeper : MonoBehaviour
{

    Rigidbody2D rigid;
    SpriteRenderer sr;

    public GameObject projectile;
    public GameObject pattern1_warning;
    public GameObject shockwave;
    public GameObject pattern3_whip;
    public GameObject pattern3_warning;
    public GameObject pattern4_mob;
    AudioSource audioSource;
    private GameObject player;
    private GameObject pattern1_collider;
    public AudioClip PatternJump;
    public AudioClip PatternImpact;
    public AudioClip WarHorn;
    public AudioClip Throw;
    public AudioClip Whip;
    float is2phase = 1;
    const float MAXHP = 40;
    float hp = MAXHP;
    int toPlayer = 1;
    public GameObject hpbar;
    public static int isEnd = 0;
    public bool pattern_reset = true;
    
    
    void Start()
    {
        hpbar.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        pattern1_collider = transform.GetChild(0).gameObject;
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        BossHp.value = hp / MAXHP;
        if(PlayerCtrl.Hp <= 0)
        {
            isEnd = 0;
            hp = MAXHP;
        }

        if (PlayerCtrl.isCanMove)
        {
            if (pattern_reset)
                StartCoroutine(pattern_manager());

            //체력이 절반 이하 일 때 페이즈 2
            if (hp <= (MAXHP * 0.5f))
            {
                is2phase = 0.5f;
            }

            //체력 0 == 죽음
            if (hp <= 0)
            {
                hpbar.SetActive(false);
                isEnd = 1;
                Destroy(gameObject);
            }
            if (player.transform.position.x <= transform.position.x)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }

            /*시험용 
            if (Input.GetKeyDown("0"))
            {
                StartCoroutine(pattern_manager());
            }
            if (Input.GetKeyDown("1"))
            {
                StartCoroutine(pattern1());
            }
            if (Input.GetKeyDown("2"))
            {
                StartCoroutine(pattern2());        
            }
            if (Input.GetKeyDown("3"))
            {
                StartCoroutine(pattern3());
            }
            if (Input.GetKeyDown("4"))
            {
                StartCoroutine(pattern4());
            }
            */
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Arrow") 
        {
            StartCoroutine(hp_decrease());   
        }   
    }

    void findPlayer()
    {
        float player_x = player.transform.position.x;

        if (player_x > this.transform.position.x)
            toPlayer = 1;
        else
            toPlayer = -1;

    }
    IEnumerator hp_decrease()
    {
        hp -= PlayerStat.attack;
        sr.color = new Color(1f, 0.48f, 0.42f, 1f);
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
        Debug.Log(hp);
    }
    IEnumerator pattern_manager()
    {
        pattern_reset = false;

        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(pattern1());
            yield return new WaitForSeconds(2f);
            pattern1_collider.SetActive(false);
        }
        

        StartCoroutine(pattern2());
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(pattern3());
            yield return new WaitForSeconds(2f);
        }
        
        StartCoroutine(pattern4());
        yield return new WaitForSeconds(12f);
        pattern_reset = true;
        
    }

    IEnumerator pattern1() 
    {
        findPlayer();

        rigid.AddForce(new Vector2(Random.Range(0f, 5f) * toPlayer, 10f), ForceMode2D.Impulse);

        Vector3 warn_pos = new Vector3(this.transform.position.x, this.transform.position.y - 6.5f, 0);
        PlaySound("JUMP");
        GameObject warning_bar = Instantiate(pattern1_warning, warn_pos, Quaternion.identity);
        warning_bar.transform.SetParent(this.transform, true);
        yield return new WaitForSeconds(1.2f);

        pattern1_collider.SetActive(true);
        rigid.AddForce(new Vector2(0f, -50f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f * is2phase);
        PlaySound("IMPACT");
        Vector3 shock_pos1 = new Vector3(this.transform.position.x - 1f, this.transform.position.y - 0.8f, 0);
        Vector3 shock_pos2 = new Vector3(this.transform.position.x + 1f, this.transform.position.y - 0.8f, 0);
        Vector2 shock1_speed = new Vector2(-10f, 0);
        Vector2 shock2_speed = new Vector2(10f, 0);
        GameObject shock1 = Instantiate(shockwave, shock_pos1, Quaternion.identity);
        shock1.GetComponent<Rigidbody2D>().velocity = shock1_speed; 
        GameObject shock2 = Instantiate(shockwave, shock_pos2, Quaternion.identity);
        shock2.GetComponent<Rigidbody2D>().velocity = shock2_speed;
        shock2.GetComponent<SpriteRenderer>().flipX = true;

        

    }

    IEnumerator pattern2()
    {
        findPlayer();
        PlaySound("THROW");
        for (int i = 0; i < 3; i++)
        {
            GameObject proj = Instantiate(projectile, transform.position + new Vector3(0f, 1.5f, 0f), Quaternion.identity);
            Rigidbody2D rigid = proj.GetComponent<Rigidbody2D>();
            rigid.AddForce(new Vector2(toPlayer * (4f + Random.Range(0f, 2f)), 9f), ForceMode2D.Impulse);
        }

        yield return null;
    }


    IEnumerator pattern3() 
    {
        findPlayer();

        GameObject whip_warning = Instantiate(pattern3_warning, transform.position + new Vector3(10f*toPlayer, 0.7f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.8f * is2phase);
        PlaySound("WHIP");
        GameObject whip = Instantiate(pattern3_whip, transform.position + new Vector3(10f*toPlayer, 0.7f, 0) , Quaternion.identity);
        Destroy(whip_warning);
        yield return new WaitForSeconds(0.1f);
        Destroy(whip); 

        yield return null;
    }

    IEnumerator pattern4()
    {
        rigid.AddForce(new Vector2(0, 20f), ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.2f);
        transform.position = new Vector2(87.5f, transform.position.y);
        rigid.AddForce(new Vector2(0f, -50f), ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);

        Vector3 shock_pos1 = new Vector3(this.transform.position.x - 1f, this.transform.position.y - 0.8f, 0);
        Vector2 shock1_speed = new Vector2(-10f, 0);
        GameObject shock1 = Instantiate(shockwave, shock_pos1, Quaternion.identity);
        shock1.GetComponent<Rigidbody2D>().velocity = shock1_speed;
        PlaySound("SPAWN");
        for (int i = 0; i < 3; i++)
        {
            
            Instantiate(pattern4_mob, new Vector2(81.62f, -25.8f), Quaternion.identity).GetComponent<Transform>();
            
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    void PlaySound(string action)
    {
        switch (action)
        {
            case "IMPACT":
                audioSource.clip = PatternImpact;
                break;
            case "JUMP":
                audioSource.clip = PatternJump;
                break;
            case "SPAWN":
                audioSource.clip = WarHorn;
                break;
            case "THROW":
                audioSource.clip = Throw;
                break;
            case "WHIP":
                audioSource.clip = Whip;
                break;


        }
        audioSource.Play();


    }


}
