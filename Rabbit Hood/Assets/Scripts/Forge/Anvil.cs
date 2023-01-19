using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using forgechoice;

public class Anvil : MonoBehaviour
{
    public GameObject choice;

    public GameObject canvas;
    public GameObject forge_title;
    public GameObject forge_description;

    const int max_num = 4;
    const int choice_num = 3;
    bool isActivated = false;

    Forge[] fr = new Forge[max_num];
    PlayerStat playerStat;

    string[] names = new string[choice_num];
    GameObject[] choices = new GameObject[choice_num];
    TextMeshProUGUI[] titles = new TextMeshProUGUI[choice_num];
    TextMeshProUGUI[] descriptions = new TextMeshProUGUI[choice_num];
    Image[] buttons = new Image[choice_num];

    
    private void Start()
    {
        playerStat = new PlayerStat();

        switch (SceneManager.GetActiveScene().name)
        {
            case "RabbitForge1":
                fr[0] = new Forge("double_jump", "���� ����", "���� Ƚ���� 2������ �þ�ϴ�.", null);
                fr[1] = new Forge("bold_guy", "�� ū �༮", "���ݷ��� 50% ���������� �ִ� ü���� 1 �����մϴ�.", null);
                fr[2] = new Forge("sniper", "��������", "ȭ���� �ӵ��� ũ�� �����ϰ� �������� 100% ����������, ���� �ӵ��� ������ �˴ϴ�.", null);
                fr[3] = new Forge("strong_heart", "���� �����", "�ִ� ü���� 2 �����մϴ�.", null);
                break;

            case "RabbitForge2":
                fr[0] = new Forge("forked_arrow", "���� ȭ��", "ȭ���� ���ÿ� �� �� �߻�˴ϴ�.", null);
                fr[1] = new Forge("quick_evasion", "����� ȸ��", "XŰ�� ���� �뽬�� �� �ֽ��ϴ�. �뽬�ϴ� ������ ���� ���°� �˴ϴ�. �뽬�� ��Ÿ���� �����մϴ�.", null);
                fr[2] = new Forge("hand_bow", "�ڵ庸��", "���� �� 3�� ���� ���ݷ� X 2 �� �������� �ִ� ȭ���� �߰��� �߻��մϴ�.", null);
                fr[3] = new Forge("minato", "��ڽ�", "ȭ�쿡 �����̵��� �� �ִ� ���� �Ҿ�ֽ��ϴ�.", null);
                break;

            case "RabbitForge3":
                fr[0] = new Forge("arrow_rain", "ȭ��� ������", "0.25�� ���� �� �ϴÿ� ������ ȭ���� ���ϴ�. ��� ��, ���ݷ��� 50% �������� �ִ� ȭ���� ������ �������ϴ�. (��Ÿ�� : 10��)", null);
                fr[1] = new Forge("powerful_shot", "������ �ѹ�", "0.5�� ������ �� ������ ȭ���� �߻��մϴ�. (��Ÿ�� : 6��)", null);
                fr[2] = new Forge("cyclone", "��ǳ", "2.5�� ���� ���ݼӵ��� �̵��ӵ��� 50% �����մϴ�. (��Ÿ�� : 7��)", null);
                fr[3] = new Forge("strong_heart", "���� �����", "�ִ� ü���� 2 �����մϴ�.", null);
                break;

        }
    }

    void Update()
    {
        if (isActivated)
        {
            if (buttons[0].fillAmount == 1)
                endingForge(0);
            else if (buttons[1].fillAmount == 1)
                endingForge(1);
            else if (buttons[2].fillAmount == 1)
                endingForge(2);
        }
        if (Input.GetKeyUp("0") && !isActivated)
        {
            printingChoices();
            isActivated = true;
        }
    }

    void printingChoices()
    {
        for (int i = 0; i < choice_num; i++)
        {
            //������Ʈ ���� �� �迭�� �ֱ�
            choices[i] = Instantiate(choice);
            //��Ŀ ��ġ ����
            RectTransform rect = choices[i].GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.25f * (i + 1), 0.5f);
            rect.anchorMax = new Vector2(0.25f * (i + 1), 0.5f);
            //ĵ���� �θ� ���� -> ȭ�鿡 ����
            choices[i].transform.SetParent(canvas.transform, false);
            //�� ��� �����Ͽ� �迭�� ����
            GameObject forge_title = choices[i].transform.GetChild(0).gameObject;
            GameObject forge_description = choices[i].transform.GetChild(1).gameObject;
            GameObject forge_button = choices[i].transform.GetChild(2).gameObject.transform.GetChild(1).gameObject;

            titles[i] = forge_title.GetComponent<TextMeshProUGUI>();
            descriptions[i] = forge_description.GetComponent<TextMeshProUGUI>();
            buttons[i] = forge_button.GetComponent<Image>();

        }
        int ex_num = excluding_num(); int j = 0;
        for(int i = 0; i < max_num; i++)
        {
            if (ex_num == i)
                continue;
            names[j] = fr[i].name;
            titles[j].text = fr[i].title;
            descriptions[j].text = fr[i].description;

        }
    }

    int excluding_num()
    {
        int ex;
        ex = Random.Range(0, 4);
        return ex;
    }

    void endingForge(int i)
    {
        playerStat.statupdate(names[i]);

        Destroy(choices[0]); Destroy(choices[1]); Destroy(choices[2]);
        isActivated = false;
    }
}
