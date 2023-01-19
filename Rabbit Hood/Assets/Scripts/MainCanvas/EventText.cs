using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EventText : MonoBehaviour
{
    public SpriteRenderer KingSprite;
    public GameObject PlayerText;
    public GameObject MonsterText;
    public GameObject DoorKeeperText;
    public GameObject GuardianText;
    public GameObject WhiteWolfText;
    public GameObject KingText;
    public GameObject TextUI;
    public TextMeshProUGUI text;
    public GameObject DKObject;
    public GameObject GDObject;
    public GameObject GDStone;
    public GameObject WWObject;
    public GameObject KingObject;
    public GameObject Player;
    public GameObject FinalWW;
    public GameObject Ending;
    public Rigidbody2D DKRigid;
    public Rigidbody2D KingRigid;
    public Rigidbody2D PlayerRigid;
    public static int Work = 0;
    private int stack = 0;
    public static bool DKAppear = false;
    public static bool GDAppear = false;
    public static bool WWAppear = false;
    private bool NextText = false;
    AudioSource audioSource;
    public AudioClip Boss1Appear;
    public GameObject Boss2Portal;
    public static int FinalBgmPhase = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Work = 0;
        DKAppear = false;
        GDAppear = false;
        WWAppear = false;
    }
    IEnumerator Appearance()
    {
        DKAppear = true;
        DKObject.SetActive(true);
        DKRigid.AddForce(Vector2.down * 20f, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        audioSource.clip = Boss1Appear;
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        stack++;
    }
    IEnumerator TextCool()
    {
        yield return new WaitForSeconds(0.5f);
        NextText = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (DKSensor.Boss1start && Work == 0 && PlayerStat.Stage <= 1 && Boss_DoorKeeper.isEnd == 0)
        {

            if (Input.GetKeyUp(KeyCode.Space) && NextText)
            {
                stack++;
                NextText = false;
                StartCoroutine(TextCool());
            }


            switch (stack)
            {
                case 0:
                    PlayerCtrl.isCanMove = false;

                    MonsterText.SetActive(true);
                    TextUI.SetActive(true);
                    text.text = "누구냐!!";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    MonsterText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "전 길 잃은 가여운 토끼에요.. 좀 지나갈게요!";
                    break;
                case 2:
                    MonsterText.SetActive(true);
                    PlayerText.SetActive(false);
                    text.text = "그렇군! 지금 침입자가 여길 돌아다니고 있으니 조심해라!";
                    break;
                case 3:
                    MonsterText.SetActive(false);
                    DoorKeeperText.SetActive(true);
                    text.text = "야 이 멍청아!!!";
                    break;
                case 4:
                    stack++;
                    DoorKeeperText.SetActive(false);
                    TextUI.SetActive(false);
                    StartCoroutine(Appearance());
                    break;
                case 6:
                    TextUI.SetActive(true);
                    MonsterText.SetActive(false);
                    DoorKeeperText.SetActive(true);
                    text.text = "쟤가 그 침입자잖아 멍청아! 옷에 피 묻은거 안보여?";
                    StartCoroutine(TextCool());
                    break;
                case 7:
                    MonsterText.SetActive(true);
                    DoorKeeperText.SetActive(false);
                    text.text = "헉!!!";
                    break;
                case 8:
                    MonsterText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "(쉽게 넘어가진 않네...)";
                    break;
                case 9:
                    PlayerText.SetActive(false);
                    DoorKeeperText.SetActive(true);
                    text.text = "여길 지나갈 수 있을거란 생각은 마라!";
                    break;
                case 10:
                    DoorKeeperText.SetActive(false);
                    TextUI.SetActive(false);
                    Work++;
                    stack = 0;
                    PlayerCtrl.isCanMove = true;
                    break;

            }

        }
        if (Boss_DoorKeeper.isEnd == 1 && Work == 1)
        {
            if (Input.GetKeyUp(KeyCode.Space) && NextText)
            {
                stack++;
                NextText = false;
                StartCoroutine(TextCool());
            }


            switch (stack)
            {
                case 0:
                    PlayerCtrl.isCanMove = false;

                    MonsterText.SetActive(true);
                    TextUI.SetActive(true);
                    text.text = "으악!!! 비상!!!!!!";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    PlayerCtrl.isCanMove = true;
                    Boss_DoorKeeper.isEnd = 2;
                    MonsterText.SetActive(false);
                    TextUI.SetActive(false);
                    NextText = false;
                    Work = 0;
                    stack = 0;
                    break;

            }



        }
        if (GDSensor.Boss2start && Work == 0 && PlayerStat.Stage <= 3 && Guardian_pattern.isEnd == 0)
        {
            if (Input.GetKeyUp(KeyCode.Space) && NextText)
            {
                stack++;
                NextText = false;
                StartCoroutine(TextCool());
            }
            switch (stack)
            {
                case 0:
                    PlayerCtrl.isCanMove = false;
                    TextUI.SetActive(true);
                    GuardianText.SetActive(true);
                    text.text = "용케 여기까지 왔군.";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    GuardianText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "헤헤 칭찬 감사합니다..";
                    break;
                case 2:
                    GuardianText.SetActive(true);
                    PlayerText.SetActive(false);
                    text.text = "자네 이름은 뭐지?";
                    break;
                case 3:
                    GuardianText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = PlayerStat.Name + "입니다!";
                    break;
                case 4:
                    GuardianText.SetActive(true);
                    PlayerText.SetActive(false);
                    text.text = "그래 " + PlayerStat.Name + "!! 늑대들의 요새에 온걸 환영한다.";
                    break;
                case 5:
                    text.text = "그럼 환영식 거하게 열어볼까? 준비는 됐나?";
                    break;
                case 6:
                    GuardianText.SetActive(false);
                    MonsterText.SetActive(true);
                    text.text = "네 준비 됐습니다!!";
                    GDAppear = true;

                    break;
                case 7:
                    GuardianText.SetActive(true);
                    MonsterText.SetActive(false);
                    text.text = PlayerStat.Name + "(이)가 받을 수 있게 던져줘라!";
                    break;
                case 8:
                    GuardianText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "(이 동네는 환영식이 특이하구나..)";
                    break;
                case 9:
                    PlayerText.SetActive(false);
                    TextUI.SetActive(false);
                    Work++;
                    stack = 0;
                    PlayerCtrl.isCanMove = true;
                    GDStone.SetActive(true);
                    break;
            }
        }
        if (Guardian_pattern.isEnd == 1 && Work == 1)
        {
            if (Input.GetKeyUp(KeyCode.Space) && NextText)
            {
                stack++;
                NextText = false;
                StartCoroutine(TextCool());
            }


            switch (stack)
            {
                case 0:
                    PlayerCtrl.isCanMove = false;

                    GuardianText.SetActive(true);
                    TextUI.SetActive(true);
                    text.text = "화....환영한다...";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    GuardianText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "??..";
                    break;

                case 2:
                    GDObject.SetActive(false);
                    GDStone.SetActive(false);
                    PlayerCtrl.isCanMove = true;
                    Guardian_pattern.isEnd = 2;
                    MonsterText.SetActive(false);
                    TextUI.SetActive(false);
                    PlayerText.SetActive(false);
                    Boss2Portal.SetActive(true);
                    Work = 0;
                    stack = 0;
                    NextText = false;

                    break;

            }

        }
        if (WWSensor.Boss3Start && Work == 0 && PlayerStat.Stage <= 5 && Boss_WhiteWolfCtrl.isEnd == 0)
        {
            if (Input.GetKeyUp(KeyCode.Space) && NextText)
            {
                stack++;
                NextText = false;
                StartCoroutine(TextCool());
            }
            switch (stack)
            {
                case 0:
                    PlayerCtrl.isCanMove = false;
                    TextUI.SetActive(true);
                    PlayerText.SetActive(true);
                    text.text = "역시 여기 있을줄 알았어! 돌아가자 하울";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    PlayerText.SetActive(false);
                    WhiteWolfText.SetActive(true);
                    text.text = "...";
                    StartCoroutine(TextCool());
                    break;
                case 2:
                    PlayerText.SetActive(true);
                    WhiteWolfText.SetActive(false);
                    text.text = "왜 그래? 몸도 많이 다친 것 처럼 보이는데";
                    StartCoroutine(TextCool());
                    break;
                case 3:
                    PlayerText.SetActive(false);
                    WhiteWolfText.SetActive(true);
                    text.text = "...";
                    WWAppear = true;
                    StartCoroutine(TextCool());
                    break;
                case 4:
                    PlayerText.SetActive(true);
                    WhiteWolfText.SetActive(false);
                    text.text = "어..어?? 뭐야 왜 그래!! (제정신이 아닌데?)";
                    StartCoroutine(TextCool());
                    break;
                case 5:
                    PlayerText.SetActive(false);
                    WhiteWolfText.SetActive(false);
                    TextUI.SetActive(false);
                    PlayerCtrl.isCanMove = true;
                    Work++;
                    stack = 0;
                    NextText = false;
                    break;
            }
        }
        if (Boss_WhiteWolfCtrl.isEnd == 1 && Work == 1)
        {
            if (Input.GetKeyUp(KeyCode.Space) && NextText)
            {
                stack++;
                NextText = false;
                StartCoroutine(TextCool());
            }
            switch (stack)
            {
                case 0:
                    PlayerCtrl.isCanMove = false;
                    TextUI.SetActive(true);
                    PlayerText.SetActive(true);
                    text.text = "그만!!!!!!!!!!";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    text.text = "널 더이상 다치게 하고 싶지않아 정신 좀 차려";
                    StartCoroutine(TextCool());
                    break;
                case 2:
                    PlayerText.SetActive(false);
                    WhiteWolfText.SetActive(true);
                    text.text = "...";
                    StartCoroutine(TextCool());
                    break;
                case 3:
                    PlayerText.SetActive(false);
                    WhiteWolfText.SetActive(false);
                    TextUI.SetActive(false);
                    PlayerCtrl.isCanMove = true;
                    Work++;
                    stack = 0;
                    NextText = false;
                    break;
            }
        }
        if (Boss_WhiteWolfCtrl.isEnd == 2 && Work == 2)
        {
            if (Input.GetKeyUp(KeyCode.Space) && NextText)
            {
                stack++;
                NextText = false;
                StartCoroutine(TextCool());
            }
            switch (stack)
            {
                case 0:
                    PlayerStat.Stage = 5;
                    PlayerCtrl.isCanMove = false;
                    TextUI.SetActive(true);
                    WhiteWolfText.SetActive(true);
                    text.text = "윽!!";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    WhiteWolfText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "괜찮아?";
                    StartCoroutine(TextCool());
                    break;
                case 2:
                    WhiteWolfText.SetActive(true);
                    PlayerText.SetActive(false);
                    text.text = "미안해..";
                    StartCoroutine(TextCool());
                    break;
                case 3:
                    WhiteWolfText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "미안할 것 없어. 빨리 돌아가자..";
                    StartCoroutine(TextCool());
                    break;
                case 4:
                    KingObject.SetActive(true);
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "잠깐, 그 놈은 못 데려간다.";
                    StartCoroutine(TextCool());
                    break;
                case 5:
                    PlayerCtrl.Hp = PlayerStat.maxHP;
                    WWAppear = false;
                    WWObject.SetActive(false);
                    FinalBgmPhase = 1;
                    PlayerText.SetActive(true);
                    KingText.SetActive(false);
                    text.text = "???";
                    StartCoroutine(TextCool());
                    break;
                case 6:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "그녀석은 나를 이어 이 부족을 이끌어야만 한다";
                    StartCoroutine(TextCool());
                    break;
                case 7:
                    PlayerText.SetActive(true);
                    KingText.SetActive(false);
                    text.text = "얘가 원하지 않는데도?";
                    StartCoroutine(TextCool());
                    break;
                case 8:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "그건 아무 상관이 없다. 그게 왕족의 피를 이어받은 자들의 운명이고 책무다.";
                    StartCoroutine(TextCool());
                    break;
                case 9:
                    PlayerText.SetActive(true);
                    KingText.SetActive(false);
                    text.text = "운명이고 책무고 난 그딴거 모르겠고 얘는 자유를 원하니까 난 그걸 줄거야";
                    StartCoroutine(TextCool());
                    break;
                case 10:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "말이 안통하는군... 너를 제거해야 얘도 정신을 차리겠구나!!";
                    StartCoroutine(TextCool());
                    break;
                case 11:
                    PlayerText.SetActive(false);
                    KingText.SetActive(false);
                    TextUI.SetActive(false);
                    PlayerCtrl.isCanMove = true;
                    Boss_WhiteWolfCtrl.isEnd = 3;
                    stack = 0;
                    NextText = false;

                    break;








            }
        }
        if (FinalBgmPhase == 3)
        {
            switch (stack)
            {
                case 0:
                    PlayerCtrl.isCanMove = false;
                    TextUI.SetActive(true);
                    PlayerText.SetActive(true);
                    text.text = "뭐지? 몸이 안움직여!";
                    StartCoroutine(FinalDelay());
                    break;
                case 1:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "용케 잘 버텼군 하지만 그것도 여기까지다.";
                    StartCoroutine(FinalDelay());
                    break;
                case 2:
                    KingText.SetActive(false);
                    TextUI.SetActive(false);
                    stack++;
                    NextText = false;
                    StartCoroutine(FinalAnim()); 
                    break;
                case 4:
                    PlayerRigid.bodyType = RigidbodyType2D.Dynamic;
                    PlayerText.SetActive(true);
                    TextUI.SetActive(true);
                    text.text = "하울!!!!";
                    StartCoroutine(FinalDelay());
                    break;
                case 5:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "쓸모없는 녀석, 끝까지 토끼편을 들다니!!";
                    StartCoroutine(FinalDelay());
                    break;
                case 6:
                    text.text = "그래 꺼져라, 너 같이 약한놈은 우리 부족에 필요도 없다.";
                    StartCoroutine(FinalDelay());
                    break;
                case 7:
                    KingText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "하울한테도 너같은 아버지는 필요 없어.";
                    StartCoroutine(FinalDelay());
                    break;
                case 8:
                    text.text = "가자 하울.";
                    StartCoroutine(FinalDelay());
                    break;
                case 9:
                    PlayerText.SetActive(false);
                    TextUI.SetActive(false);
                    Ending.SetActive(true);
                    FinalBgmPhase = 4;
                    break;
            }
        }
    }
    IEnumerator FinalAnim()
    {
        for(int i = 0; i<PlayerCtrl.Hp-1; i++)
        {
            if (Player.transform.position.x < KingObject.transform.position.x)
                KingSprite.flipX = false;
            else
                KingSprite.flipX = true;
            KingRigid.AddForce(new Vector2(Player.transform.position.x, Player.transform.position.y) * 10f, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1f);
            NextText = false;
        }
        if (Player.transform.position.x < KingObject.transform.position.x)
            KingSprite.flipX = false;
        else
            KingSprite.flipX = true;
        KingRigid.AddForce(new Vector2(Player.transform.position.x, Player.transform.position.y) * 10f, ForceMode2D.Impulse);
        FinalWW.SetActive(true);
        FinalWW.transform.position = new Vector2(Player.transform.position.x+1f, Player.transform.position.y);
        yield return new WaitForSeconds(2f);
        stack++;
    }
    IEnumerator FinalDelay()
    {
        yield return new WaitForSeconds(1f);
        stack++;
    }
}
