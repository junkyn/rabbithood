using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2Ctrl : MonoBehaviour
{
    public GameObject player;
    public GameObject Monster;
    private float moveSpeed;
    public float MobHp = 3;
    public GameObject sword;
    public SpriteRenderer sword_rend;
    public SpriteRenderer rend;
    public Rigidbody2D rigid;
    private bool PlayerSensor = false;
    private bool isCanAttack = true;
    private bool isCanDamage = true;
    AudioSource audioSource;
    public AudioClip AudioAttack;
    float currentPosition;
    float tempPosition;
    float direction = 0.5f;
    private bool isBlocked = false;
    private bool FirstAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        tempPosition = transform.position.x;
        currentPosition = transform.position.x;
        moveSpeed = 1f;
        audioSource = GetComponent<AudioSource>();
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = Setting._EffectVolume;

        if (PlayerCtrl.isCanMove)
        {
            if (MobHp <= 0)
            {
                Destroy(gameObject);
            }
            if (Vector3.Distance(player.transform.position, transform.position) < 2f && (player.transform.position.y - transform.position.y < 1f || transform.position.y - player.transform.position.y < 1f))
            {
                PlayerSensor = true;
            }
            if (PlayerSensor && FirstAttack)
            {
                rend.enabled = true;
                if (player.transform.position.x > this.transform.position.x)
                {
                    rigid.AddForce(Vector2.right * 6f, ForceMode2D.Impulse);
                    rend.flipX = false;
                }
                else if (player.transform.position.x < this.transform.position.x)
                {
                    rigid.AddForce(Vector2.left * 6f, ForceMode2D.Impulse);
                    rend.flipX = true;
                }
                FirstAttack = false;
            }
            else if (PlayerSensor)
            {
                if (player.transform.position.x > this.transform.position.x)
                {
                    this.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

                    rend.flipX = false;
                }
                else if (player.transform.position.x < this.transform.position.x)
                {
                    this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

                    rend.flipX = true;
                }

            }
            else if (PlayerSensor == false)
            {
                if (isBlocked)
                {
                    if (rend.flipX == true)
                        rend.flipX = false;
                    else if (rend.flipX == false)
                        rend.flipX = true;
                    direction *= -1;
                    isBlocked = false;
                }
                else if (isBlocked == false)
                {
                    tempPosition += Time.deltaTime * direction;
                    if (tempPosition >= currentPosition + 2f)
                    {
                        rend.flipX = true;

                        direction *= -1;

                    }
                    else if (tempPosition <= currentPosition - 2f)
                    {
                        rend.flipX = false;
                        direction *= -1;
                    }
                    transform.position = new Vector3(tempPosition, transform.position.y, transform.position.z);
                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Arrow")
        {
            if (PlayerSensor == false)
                PlayerSensor = true;
            if (col.GetComponent<Arrow>().Damaged == false)
            {
                MobHp = MobHp - PlayerStat.attack;
                col.GetComponent<Arrow>().Damaged = true;
            }
        }
        if (col.tag == "Wall")
        {
            isBlocked = true;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && isCanAttack && PlayerCtrl.isCanMove)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        PlaySound("ATTACK");

        if (player.transform.position.x > this.transform.position.x)
        {
            sword.transform.position = new Vector3(transform.position.x + 0.66f, transform.position.y + 0.03f, transform.position.z);
            sword_rend.flipX = false;
        }
        else if (player.transform.position.x < this.transform.position.x)
        {
            sword.transform.position = new Vector3(transform.position.x - 0.59f, transform.position.y + 0.03f, transform.position.z);

            sword_rend.flipX = true;
        }
        isCanAttack = false;
        sword.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        sword.SetActive(false);
        isCanAttack = true;
    }
    IEnumerator DamageCool()
    {
        yield return new WaitForSeconds(0.3f);
        isCanDamage = true;
    }
    void PlaySound(string action)
    {
        switch (action)
        {
            case "ATTACK":
                audioSource.clip = AudioAttack;
                break;
        }
        audioSource.Play();


    }

}
