using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3Ctrl : MonoBehaviour
{
    public GameObject player;
    private float moveSpeed;
    public GameObject sword;
    public SpriteRenderer sword_rend;
    public float MobHp = 4;
    public SpriteRenderer rend;
    public Rigidbody2D rigid;
    private bool PlayerSensor = false;
    private bool isCanAttack = true;
    private bool isCanDamage = true;
    AudioSource audioSource;
    public AudioClip AudioAttack;
    public AudioClip AudioSpawn;
    float currentPosition;
    float tempPosition;
    float direction = 0.5f;
    private bool isBlocked = false;
    public Transform tr;
    public GameObject Monster_prefab;
    GameObject monster1;
    GameObject monster2;
    private int spawning = 0;
    // Start is called before the first frame update
    void Start()
    {
        tr = this.GetComponent<Transform>();
        tempPosition = transform.position.x;
        currentPosition = transform.position.x;
        moveSpeed = 1f;
        audioSource = GetComponent<AudioSource>();
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
            if (PlayerSensor && spawning == 0)
            {
                StartCoroutine(Spawning());
                spawning = 1;
            }
            else if (PlayerSensor && spawning == 2)
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
        if (col.tag == "Player" && isCanAttack)
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
            sword_rend.flipX = true;
        }
        else if (player.transform.position.x < this.transform.position.x)
        {
            sword.transform.position = new Vector3(transform.position.x - 0.59f, transform.position.y + 0.03f, transform.position.z);

            sword_rend.flipX = false;
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
    IEnumerator Spawning()
    {
        PlaySound("SPAWN");
        yield return new WaitForSeconds(0.5f);
        monster1 = Instantiate(Monster_prefab, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), Monster_prefab.transform.rotation, tr);
        monster1.SetActive(true);
        monster2 = Instantiate(Monster_prefab, new Vector3(transform.position.x -1f, transform.position.y, transform.position.z), Monster_prefab.transform.rotation, tr);
        monster2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        spawning = 2;
    }
    void PlaySound(string action)
    {
        switch (action)
        {
            case "ATTACK":
                audioSource.clip = AudioAttack;
                break;
            case "SPAWN":
                audioSource.clip = AudioSpawn;
                break;
        }
        audioSource.Play();


    }

}
