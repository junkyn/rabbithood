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

        fr[0] = new Forge("double_jump", "더블 점프", "점프 횟수가 2번으로 늘어납니다.", null);
        fr[1] = new Forge("bold_guy", "간 큰 녀석", "공격력이 50% 증가하지만 최대 체력이 1 감소합니다.", null);
        fr[2] = new Forge("sniper", "스나이퍼", "화살의 속도가 크게 증가하고 데미지가 100% 증가하지만, 공격 속도가 절반이 됩니다.", null);
        fr[3] = new Forge("strong_heart", "강한 생명력", "최대 체력이 2 증가합니다.", null);
                
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
        Destroy(gameObject);
    }
}
