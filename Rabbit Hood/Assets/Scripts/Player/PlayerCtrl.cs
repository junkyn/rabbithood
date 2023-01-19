using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour    
{
    public Transform tr;
    public Rigidbody2D rigid;
    public SpriteRenderer rend;
    private float moveSpeed;
    private bool isCanJump;
    public static bool isCanAttack;
    public static bool isCanDamage;
    public GameObject Arrow_prefab;
    public GameObject TeleportArrow_prefab;
    public Animator animator;
    public static int Hp;
    public Sprite NoHp;
    public Sprite FullHp;
    public Image[] hearts;
    public AudioClip audioJump_Castle;
    public AudioClip audioAttack;
    public AudioClip audioDamaged;
    public AudioClip audioDash;
    public AudioClip audioHandbow;
    AudioSource audioSource;
    private bool CanDash = true;
    private int DashStack = 0;

    private int HandBowStack = 0;
    private float TempDamage;
    SpriteRenderer ArrowRend;
    public bool CanTeleport = true;
    public static bool isCanMove;

    // Start is called before the first frame update
    void Start()
    {
 
        isCanMove = true;
        tr = this.GetComponent<Transform>();
        moveSpeed = PlayerStat.moveSpeed;
        isCanJump = true;
        isCanAttack = true;
        isCanDamage = true;
        this.audioSource = GetComponent<AudioSource>();
        Hp = PlayerStat.maxHP;
        ArrowRend = Arrow_prefab.GetComponent<SpriteRenderer>();
        TempDamage = PlayerStat.attack;
    }



    // Update is called once per frame
    void Update()
    {
        
        audioSource.volume = Setting._EffectVolume;
        for (int i = 0; i < 7; i++)
        {
            if (i < PlayerStat.maxHP && hearts[i].color.a == 0)
            {
                hearts[i].color = new Color(255, 68, 68, 255);
            }
            if (i >= PlayerStat.maxHP-1 && hearts[i].color.a == 255)
            {
                hearts[i].color = new Color(255, 68, 68, 0);
            }
        }
        for (int i = 0; i < PlayerStat.maxHP; i++)
        {
     
            if (i < Hp)
            {
                hearts[i].sprite = FullHp;

            }
            else
            {
                hearts[i].sprite = NoHp;
            }
        }

        if (Hp <= 0)
            isCanMove = false;
        if (isCanMove)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                tr.position += Vector3.right * moveSpeed * Time.deltaTime;
                rend.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                tr.position += Vector3.left * moveSpeed * Time.deltaTime;
                rend.flipX = true;
            }
            if (isCanJump && Input.GetKeyDown(KeyCode.UpArrow))
            {
                rigid.AddForce(Vector2.up * 5.5f, ForceMode2D.Impulse);
                PlaySound("JUMP_CASTLE");
                isCanJump = false;
                if (PlayerStat.jumpnum == 2)
                {
                    PlayerStat.jumpnum = 3;
                    isCanJump = true;
                }

            }
            if (CanTeleport && PlayerStat.isteleport && Input.GetKeyDown(KeyCode.X))
            {
                PlaySound("ATTACK");

                if (rend.flipX == false)
                {
                    Instantiate(TeleportArrow_prefab, new Vector3(transform.position.x + 0.2f, transform.position.y - 0.04f, transform.position.z), Arrow_prefab.transform.rotation, tr);
                }

                if (rend.flipX)
                {
                    Instantiate(TeleportArrow_prefab, new Vector3(transform.position.x - 0.2f, transform.position.y - 0.04f, transform.position.z), Arrow_prefab.transform.rotation, tr);
                }

                StartCoroutine(TeleportCooltime());


            }
            if (TeleportArrow.Arrived)
            {
                tr.position = new Vector3(TeleportArrow.arrow_x, TeleportArrow.arrow_y, tr.position.z);
                TeleportArrow.Arrived = false;
            }
            if (CanDash && PlayerStat.isquickavoid && Input.GetKeyDown(KeyCode.X))
            {
                if (rend.flipX == false)
                    StartCoroutine(Dash(1));
                if (rend.flipX == true)
                    StartCoroutine(Dash(-1));
            }
            if (isCanAttack && Input.GetKey(KeyCode.Z))
            {
                if (PlayerStat.ishandbow)
                {
                    if (HandBowStack == 2)
                    {
                        ArrowRend.color = new Color(0, 255, 0, 255);
                        TempDamage = PlayerStat.attack;
                        PlayerStat.attack = PlayerStat.attack * 2;
                        HandBowStack = 0;
                    }
                    else
                    {
                        ArrowRend.color = new Color(255, 255, 255, 255);

                        PlayerStat.attack = TempDamage;
                        HandBowStack++;
                        Debug.Log(HandBowStack);
                    }
                }
                if (ArrowRend.color.r == 0)
                {
                    PlaySound("HANDBOW");
                }
                else
                    PlaySound("ATTACK");
                isCanAttack = false;
                if (rend.flipX == false)
                {
                    if (PlayerStat.doubleArrow)
                    {
                        Instantiate(Arrow_prefab, new Vector3(transform.position.x + 0.2f, transform.position.y+0.1f, transform.position.z), Arrow_prefab.transform.rotation, tr);
                        Instantiate(Arrow_prefab, new Vector3(transform.position.x + 0.2f, transform.position.y - 0.1f, transform.position.z), Arrow_prefab.transform.rotation, tr);

                    }
                    else if (PlayerStat.doubleArrow == false)
                        Instantiate(Arrow_prefab, new Vector3(transform.position.x + 0.2f, transform.position.y - 0.04f, transform.position.z), Arrow_prefab.transform.rotation, tr);
                }

                if (rend.flipX)
                {
                    if (PlayerStat.doubleArrow)
                    {
                        Instantiate(Arrow_prefab, new Vector3(transform.position.x - 0.2f, transform.position.y+0.1f, transform.position.z), Arrow_prefab.transform.rotation, tr);
                        Instantiate(Arrow_prefab, new Vector3(transform.position.x - 0.2f, transform.position.y - 0.1f, transform.position.z), Arrow_prefab.transform.rotation, tr);

                    }
                    else if (PlayerStat.doubleArrow == false)
                        Instantiate(Arrow_prefab, new Vector3(transform.position.x - 0.2f, transform.position.y - 0.04f, transform.position.z), Arrow_prefab.transform.rotation, tr);
                }

                StartCoroutine(AttackCooltime());
            }
        }

    }
    IEnumerator TeleportCooltime()
    {
        CanTeleport = false;
        yield return new WaitForSeconds(5f);
        CanTeleport = true;
    }
    IEnumerator Dash(int i)
    {
        Debug.Log("Dash");
        CanDash = false;
        PlaySound("DASH");
        rigid.AddForce(Vector2.right * i * 4f, ForceMode2D.Impulse);
        isCanDamage = false;
        yield return new WaitForSeconds(0.5f);
        isCanDamage = true;
        yield return new WaitForSeconds(3f);
        CanDash = true;
        Debug.Log("DashCool ok");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.CompareTag("Floor"))
        {
            isCanJump = true;
            if (PlayerStat.jumpnum == 3)
                PlayerStat.jumpnum = 2;
        }
    }
    IEnumerator AttackCooltime()
    {
        yield return new WaitForSeconds(PlayerStat.attackSpeed);
        isCanAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Monster" || col.tag == "Boss_Skill")
        {
            StartCoroutine(Damaged(col.transform.position.x - transform.position.x));
        }
    }
    IEnumerator Damaged(float i)
    {
        if (isCanDamage)
        {
            isCanDamage = false;
            Debug.Log("Hit!");
            if (i<0)
            {
                rigid.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.right * 1f, ForceMode2D.Impulse);
            }
            else
            {
                rigid.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.left * 1f, ForceMode2D.Impulse);
            }
            Hp -= 1;
            animator.SetBool("isDamaged", true);
            moveSpeed = 2f;
            yield return new WaitForSeconds(0.5f);
            animator.SetBool("isDamaged", false);
            isCanDamage = true;
            moveSpeed = 3f;


        }
    }

    void PlaySound(string action)
    {
        switch (action)
        {
            case "JUMP_CASTLE":
                audioSource.clip = audioJump_Castle;
                break;
            case "ATTACK":
                audioSource.clip = audioAttack;
                break;
            case "DASH":
                audioSource.clip = audioDash;
                break;
            case "HANDBOW":
                audioSource.clip = audioHandbow;
                break;
            //case "Damaged":
              //  audioSource.clip = audioDamaged;
                //break;

        }
        audioSource.Play();
    }
}
