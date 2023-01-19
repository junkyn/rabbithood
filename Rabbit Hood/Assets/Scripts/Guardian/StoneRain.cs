using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneRain : MonoBehaviour
{
    public bool random;
    public bool timing_random;
    public bool Heart_bool;
    public float cooltime_min;
    public float cooltime_max;

    public float Range;
    private float random_cooltime;
    public float cooltime;
    public GameObject Stone_prefab;
    public GameObject Heart_prefab;

    //random 체크시, StoneRain 게임 오브젝트의 위치로부터 Range의 x좌표 범위 안에 돌이 랜덤 위치로 떨어짐
    //ex) StoneRain x 좌표가 5이고, Range가 10이라면, x좌표 5와 15사이에서 돌이 랜덤하게 떨어짐
    // y 좌표는 StoneRain의 y좌표 그대로 따라감
    //Range 양수 음수 상관없음


    //Timing_random 체크시, 돌이 떨어지는 시간 간격을 랜덤으로 하며
    //cooltime_min, cooltime_max 설정을 통해
    //돌 떨어뜨리는 시간 간격을 조절할 수 있음
    //ex) min = 0.3, max = 1.0라면, 처음 돌이 떨어지고 다음 돌이 떨어지는데까지 가장 빠르면 0.3초뒤에 떨어지고, 가장 늦으면 1초뒤에 떨어짐


    //Timing_random 체크 안하고 일정한 초 간격으로 돌을 떨어뜨리고자 할 때는 Cooltime 사용하면 됨


    //Heart_bool; 체크시, 1/8의 확률로 플레이어의 체력을 1올려주는 하트를 떨어뜨림 (확률은 추후 조정해도 괜찮음)


    // Start is called before the first frame update
    void Start()
    {
        if (random == false)
            StartCoroutine(Stone());
        else if (random == true)
            StartCoroutine(Random_Stone());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator Stone()
    {
        if (timing_random == false)
            yield return new WaitForSeconds(cooltime);
        else
            yield return new WaitForSeconds(Random.Range(cooltime_min, cooltime_max));
        if (Heart_bool == true)
        {
            if (Random.Range(0, 8) != 7)
                Instantiate(Stone_prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Stone_prefab.transform.rotation);
            else
                Instantiate(Heart_prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Stone_prefab.transform.rotation);
        }
        else
            Instantiate(Stone_prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Stone_prefab.transform.rotation);

        StartCoroutine(Stone());
    }

    IEnumerator Random_Stone()
    {
        if (timing_random == false)
            yield return new WaitForSeconds(cooltime);
        else
            yield return new WaitForSeconds(Random.Range(cooltime_min, cooltime_max));

        if (Heart_bool == true)
        {
            if (Random.Range(0, 8) != 7)
                Instantiate(Stone_prefab, new Vector3(Random.Range((float)transform.position.x, (float)transform.position.x + Range), transform.position.y, transform.position.z), Stone_prefab.transform.rotation);
            else
                Instantiate(Heart_prefab, new Vector3(Random.Range((float)transform.position.x, (float)transform.position.x + Range), transform.position.y, transform.position.z), Stone_prefab.transform.rotation);
        }
        else
            Instantiate(Stone_prefab, new Vector3(Random.Range((float)transform.position.x, (float)transform.position.x + Range), transform.position.y, transform.position.z), Stone_prefab.transform.rotation);

        StartCoroutine(Random_Stone());
    }
}   
