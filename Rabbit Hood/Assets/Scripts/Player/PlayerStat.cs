using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static string Name;
    public static string Skill_1 = null;
    public static string Skill_2 = null;
    public static string Skill_3 = null;
    public static int Stage=-1;
    public static int maxHP = 5; // ����
    public int maxHPP = 5;
    public static float attack = 1f; // ����
    public static float moveSpeed = 3f; // ����
    public static float attackSpeed = 0.7f; // ����
    public static float arrowSpeed = 8f; // ����
    public static int jumpnum = 1; // ����
    public static bool doubleArrow = false; // ����
    public static bool isquickavoid = false; // ����
    public static bool ishandbow = false; // ����
    public static bool isteleport = false; // ����
    public static bool isarrowrain = false;
    public static bool isstrongone = false;
    public static bool iscyclone = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void statupdate(string whatisForged) 
    {
        Debug.Log(whatisForged);
        switch (whatisForged) 
        {
            case "double_jump": // ��������
                jumpnum = 2;
                Skill_1 = "double_jump";
                break;
            
            case "bold_guy": // �� ū �༮
                maxHP--;
                attack += 0.5f;
                Skill_1 = "bold_guy";
                break;
            
            case "forked_arrow": // ����ȭ��
                doubleArrow = true;
                Skill_2 = "forked_arrow";
                break;
            
            case "sniper": // ��������
                arrowSpeed += 0.5f;
                attack += 1;
                attackSpeed += 0.5f;
                Skill_1 = "sniper";
                break;
            
            case "quick_evasion": // ����� ȸ��
                isquickavoid = true;
                Skill_2 = "quick_evasion";
                break;

            case "minato": // ��ڽ�
                isteleport = true;
                Skill_2 = "minato";
                break;
            
            case "strong_heart": // ���� �����
                maxHP += 2;
                Skill_1 = "strong_heart";
                break;
            
            case "hand_bow": // �ڵ庸��
                ishandbow = true;
                Skill_2 = "hand_bow";
                break;
            
            case "ArrowRain": // ȭ��� ������
                isarrowrain = true;
                Skill_3 = "ArrowRain";
                break;
            
            case "StrongOneShot": //������ �ѹ�
                isstrongone = true;
                Skill_3 = "StrongOneShot";
                break;
            
            case "Cyclone": // ��ǳ
                iscyclone = true;
                Skill_3 = "Cyclone";
                break;

            default:
                break;

        }
    }

}
