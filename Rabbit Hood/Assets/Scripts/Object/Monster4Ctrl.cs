using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4Ctrl : MonoBehaviour
{
    public GameObject Magic_prefab;
    private GameObject player;
    private float moveSpeed;
    private float MobHp = 3f;
    public SpriteRenderer rend;
    public Rigidbody2D rigid;
    public static bool PlayerSensor = false;
    private bool isCanAttack = true;
    AudioSource audioSource;
    public AudioClip AudioMagic;
    float currentPosition;
    float tempPosition;
    float direction = 0.5f;
    private bool isBlocked = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSensor = false;
        player = FindObjectOfType<PlayerCtrl>().gameObject;
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
            if(MobHp<=0)
                Destroy(gameObject);
            if (Vector3.Distance(player.transform.position, transform.position) < 2f && (player.transform.position.y - transform.position.y < 1f || transform.position.y - player.transform.position.y < 1f))
            {
                PlayerSensor = true;
            }

            if (PlayerSensor)
            {
                if (player.transform.position.x > this.transform.position.x)
                {
                    if (isCanAttack)
                        StartCoroutine(Magic());
                    rend.flipX = false;
                }
                else if (player.transform.position.x < this.transform.position.x)
                {
                    if (isCanAttack)
                        StartCoroutine(Magic());
                    rend.flipX = true;
                }

            }
            else if(PlayerSensor == false)
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

    IEnumerator Magic()
    {
        if (rend.flipX == false)
        {
            isCanAttack = false;
            yield return new WaitForSeconds(0.5f);
            audioSource.clip = AudioMagic;
            audioSource.Play();
            Instantiate(Magic_prefab, new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z), Magic_prefab.transform.rotation, transform);
            yield return new WaitForSeconds(1f);
            isCanAttack = true;
        }
        if(rend.flipX == true)
        {
            isCanAttack = false;
            yield return new WaitForSeconds(0.5f);
            audioSource.clip = AudioMagic;
            audioSource.Play();

            Instantiate(Magic_prefab, new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z), Magic_prefab.transform.rotation, transform);
            yield return new WaitForSeconds(1f);
            isCanAttack = true;
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

}
