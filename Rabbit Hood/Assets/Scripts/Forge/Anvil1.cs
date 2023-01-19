using forgechoice;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Anvil1 : MonoBehaviour
{
    public GameObject choice;

    public GameObject canvas;
    public GameObject forge_title;
    public GameObject forge_description;

    PlayerStat playerstat;
    const int max_num = 4;
    const int choice_num = 3;
    bool isActivated = false;
    bool isused = false;

    Forge[] fr = new Forge[max_num];

    string[] names = new string[choice_num];
    GameObject[] choices = new GameObject[choice_num];
    TextMeshProUGUI[] titles = new TextMeshProUGUI[choice_num];
    TextMeshProUGUI[] descriptions = new TextMeshProUGUI[choice_num];
    Image[] buttons = new Image[choice_num];


    private void Start()
    {
        playerstat = new PlayerStat();

        fr[0] = new Forge("double_jump", "���� ����", "���� Ƚ���� 2������ �þ�ϴ�.", null);
        fr[1] = new Forge("bold_guy", "�� ū �༮", "���ݷ��� 50% ���������� �ִ� ü���� 1 �����մϴ�.", null);
        fr[2] = new Forge("sniper", "��������", "ȭ���� �ӵ��� ũ�� �����ϰ� �������� 100% ����������, ���� �ӵ��� ������ �˴ϴ�.", null);
        fr[3] = new Forge("strong_heart", "���� �����", "�ִ� ü���� 2 �����մϴ�.", null);
                
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
        
    }

    void printingChoices()
    {
        for (int i = 0; i < choice_num; i++)
        {
            //������Ʈ ���� �� �迭�� �ֱ�
            choices[i] = Instantiate(choice);
            //��Ŀ ��ġ ����
            RectTransform rect = choices[i].GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.275f * (i + 1), 0.5f);
            rect.anchorMax = new Vector2(0.275f * (i + 1), 0.5f);
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
        for (int i = 0; i < max_num; i++)
        {
            if (ex_num == i)
                continue;
            names[j] = fr[i].name;
            titles[j].text = fr[i].title;
            descriptions[j].text = fr[i].description;
            j++;

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isActivated)
        {
            isActivated = true;
            printingChoices();
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
        playerstat.statupdate(names[i]);

        Destroy(choices[0]); Destroy(choices[1]); Destroy(choices[2]);
        isActivated = false;
        Destroy(gameObject);
    }
}
