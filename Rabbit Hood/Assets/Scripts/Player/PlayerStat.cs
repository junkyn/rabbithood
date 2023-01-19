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
    public static int maxHP = 5; // 구현
    public int maxHPP = 5;
    public static float attack = 1f; // 구현
    public static float moveSpeed = 3f; // 구현
    public static float attackSpeed = 0.7f; // 구현
    public static float arrowSpeed = 8f; // 구현
    public static int jumpnum = 1; // 구현
    public static bool doubleArrow = false; // 구현
    public static bool isquickavoid = false; // 구현
    public static bool ishandbow = false; // 구현
    public static bool isteleport = false; // 구현
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
            case "double_jump": // 더블점프
                jumpnum = 2;
                Skill_1 = "double_jump";
                break;
            
            case "bold_guy": // 간 큰 녀석
                maxHP--;
                attack += 0.5f;
                Skill_1 = "bold_guy";
                break;
            
            case "forked_arrow": // 갈래화살
                doubleArrow = true;
                Skill_2 = "forked_arrow";
                break;
            
            case "sniper": // 스나이퍼
                arrowSpeed += 0.5f;
                attack += 1;
                attackSpeed += 0.5f;
                Skill_1 = "sniper";
                break;
            
            case "quick_evasion": // 재빠른 회피
                isquickavoid = true;
                Skill_2 = "quick_evasion";
                break;

            case "minato": // 비뢰신
                isteleport = true;
                Skill_2 = "minato";
                break;
            
            case "strong_heart": // 강한 생명력
                maxHP += 2;
                Skill_1 = "strong_heart";
                break;
            
            case "hand_bow": // 핸드보우
                ishandbow = true;
                Skill_2 = "hand_bow";
                break;
            
            case "ArrowRain": // 화살비가 내려와
                isarrowrain = true;
                Skill_3 = "ArrowRain";
                break;
            
            case "StrongOneShot": //강력한 한방
                isstrongone = true;
                Skill_3 = "StrongOneShot";
                break;
            
            case "Cyclone": // 돌풍
                iscyclone = true;
                Skill_3 = "Cyclone";
                break;

            default:
                break;

        }
    }

}
