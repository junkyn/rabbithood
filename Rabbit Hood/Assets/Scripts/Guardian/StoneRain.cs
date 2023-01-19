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

    //random üũ��, StoneRain ���� ������Ʈ�� ��ġ�κ��� Range�� x��ǥ ���� �ȿ� ���� ���� ��ġ�� ������
    //ex) StoneRain x ��ǥ�� 5�̰�, Range�� 10�̶��, x��ǥ 5�� 15���̿��� ���� �����ϰ� ������
    // y ��ǥ�� StoneRain�� y��ǥ �״�� ����
    //Range ��� ���� �������


    //Timing_random üũ��, ���� �������� �ð� ������ �������� �ϸ�
    //cooltime_min, cooltime_max ������ ����
    //�� ����߸��� �ð� ������ ������ �� ����
    //ex) min = 0.3, max = 1.0���, ó�� ���� �������� ���� ���� �������µ����� ���� ������ 0.3�ʵڿ� ��������, ���� ������ 1�ʵڿ� ������


    //Timing_random üũ ���ϰ� ������ �� �������� ���� ����߸����� �� ���� Cooltime ����ϸ� ��


    //Heart_bool; üũ��, 1/8�� Ȯ���� �÷��̾��� ü���� 1�÷��ִ� ��Ʈ�� ����߸� (Ȯ���� ���� �����ص� ������)


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
