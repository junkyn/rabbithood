using forgechoice;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Anvil2 : MonoBehaviour
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

        fr[0] = new Forge("forked_arrow", "갈래 화살", "화살이 동시에 두 발 발사됩니다.", null);
        fr[1] = new Forge("quick_evasion", "재빠른 회피", "X키를 눌러 대쉬할 수 있습니다. 대쉬하는 동안은 무적 상태가 됩니다. 대쉬엔 쿨타임이 존재합니다.", null);
        fr[2] = new Forge("hand_bow", "핸드보우", "공격 시 3번 마다 공격력 X 2 의 데미지를 주는 화살을 추가로 발사합니다.", null);
        fr[3] = new Forge("minato", "비뢰신", "화살에 순간이동할 수 있는 힘을 불어넣습니다.", null);

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
            //오브젝트 생성 후 배열에 넣기
            choices[i] = Instantiate(choice);
            //앵커 위치 조절
            RectTransform rect = choices[i].GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.275f * (i + 1), 0.5f);
            rect.anchorMax = new Vector2(0.275f * (i + 1), 0.5f);
            //캔버스 부모 설정 -> 화면에 나옴
            choices[i].transform.SetParent(canvas.transform, false);
            //각 요소 추출하여 배열에 넣음
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
        isused = true;
        Destroy(gameObject);
    }
}
