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
                    text.text = "������!!";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    MonsterText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "�� �� ���� ������ �䳢����.. �� �������Կ�!";
                    break;
                case 2:
                    MonsterText.SetActive(true);
                    PlayerText.SetActive(false);
                    text.text = "�׷���! ���� ħ���ڰ� ���� ���ƴٴϰ� ������ �����ض�!";
                    break;
                case 3:
                    MonsterText.SetActive(false);
                    DoorKeeperText.SetActive(true);
                    text.text = "�� �� ��û��!!!";
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
                    text.text = "���� �� ħ�����ݾ� ��û��! �ʿ� �� ������ �Ⱥ���?";
                    StartCoroutine(TextCool());
                    break;
                case 7:
                    MonsterText.SetActive(true);
                    DoorKeeperText.SetActive(false);
                    text.text = "��!!!";
                    break;
                case 8:
                    MonsterText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "(���� �Ѿ�� �ʳ�...)";
                    break;
                case 9:
                    PlayerText.SetActive(false);
                    DoorKeeperText.SetActive(true);
                    text.text = "���� ������ �� �����Ŷ� ������ ����!";
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
                    text.text = "����!!! ���!!!!!!";
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
                    text.text = "���� ������� �Ա�.";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    GuardianText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "���� Ī�� �����մϴ�..";
                    break;
                case 2:
                    GuardianText.SetActive(true);
                    PlayerText.SetActive(false);
                    text.text = "�ڳ� �̸��� ����?";
                    break;
                case 3:
                    GuardianText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = PlayerStat.Name + "�Դϴ�!";
                    break;
                case 4:
                    GuardianText.SetActive(true);
                    PlayerText.SetActive(false);
                    text.text = "�׷� " + PlayerStat.Name + "!! ������� ����� �°� ȯ���Ѵ�.";
                    break;
                case 5:
                    text.text = "�׷� ȯ���� ���ϰ� �����? �غ�� �Ƴ�?";
                    break;
                case 6:
                    GuardianText.SetActive(false);
                    MonsterText.SetActive(true);
                    text.text = "�� �غ� �ƽ��ϴ�!!";
                    GDAppear = true;

                    break;
                case 7:
                    GuardianText.SetActive(true);
                    MonsterText.SetActive(false);
                    text.text = PlayerStat.Name + "(��)�� ���� �� �ְ� �������!";
                    break;
                case 8:
                    GuardianText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "(�� ���״� ȯ������ Ư���ϱ���..)";
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
                    text.text = "ȭ....ȯ���Ѵ�...";
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
                    text.text = "���� ���� ������ �˾Ҿ�! ���ư��� �Ͽ�";
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
                    text.text = "�� �׷�? ���� ���� ��ģ �� ó�� ���̴µ�";
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
                    text.text = "��..��?? ���� �� �׷�!! (�������� �ƴѵ�?)";
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
                    text.text = "�׸�!!!!!!!!!!";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    text.text = "�� ���̻� ��ġ�� �ϰ� �����ʾ� ���� �� ����";
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
                    text.text = "��!!";
                    StartCoroutine(TextCool());
                    break;
                case 1:
                    WhiteWolfText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "������?";
                    StartCoroutine(TextCool());
                    break;
                case 2:
                    WhiteWolfText.SetActive(true);
                    PlayerText.SetActive(false);
                    text.text = "�̾���..";
                    StartCoroutine(TextCool());
                    break;
                case 3:
                    WhiteWolfText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "�̾��� �� ����. ���� ���ư���..";
                    StartCoroutine(TextCool());
                    break;
                case 4:
                    KingObject.SetActive(true);
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "���, �� ���� �� ��������.";
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
                    text.text = "�׳༮�� ���� �̾� �� ������ �̲���߸� �Ѵ�";
                    StartCoroutine(TextCool());
                    break;
                case 7:
                    PlayerText.SetActive(true);
                    KingText.SetActive(false);
                    text.text = "�갡 ������ �ʴµ���?";
                    StartCoroutine(TextCool());
                    break;
                case 8:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "�װ� �ƹ� ����� ����. �װ� ������ �Ǹ� �̾���� �ڵ��� ����̰� å����.";
                    StartCoroutine(TextCool());
                    break;
                case 9:
                    PlayerText.SetActive(true);
                    KingText.SetActive(false);
                    text.text = "����̰� å���� �� �׵��� �𸣰ڰ� ��� ������ ���ϴϱ� �� �װ� �ٰž�";
                    StartCoroutine(TextCool());
                    break;
                case 10:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "���� �����ϴ±�... �ʸ� �����ؾ� �굵 ������ �����ڱ���!!";
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
                    text.text = "����? ���� �ȿ�����!";
                    StartCoroutine(FinalDelay());
                    break;
                case 1:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "���� �� ���ᱺ ������ �װ͵� ���������.";
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
                    text.text = "�Ͽ�!!!!";
                    StartCoroutine(FinalDelay());
                    break;
                case 5:
                    PlayerText.SetActive(false);
                    KingText.SetActive(true);
                    text.text = "������� �༮, ������ �䳢���� ��ٴ�!!";
                    StartCoroutine(FinalDelay());
                    break;
                case 6:
                    text.text = "�׷� ������, �� ���� ���ѳ��� �츮 ������ �ʿ䵵 ����.";
                    StartCoroutine(FinalDelay());
                    break;
                case 7:
                    KingText.SetActive(false);
                    PlayerText.SetActive(true);
                    text.text = "�Ͽ����׵� �ʰ��� �ƹ����� �ʿ� ����.";
                    StartCoroutine(FinalDelay());
                    break;
                case 8:
                    text.text = "���� �Ͽ�.";
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
