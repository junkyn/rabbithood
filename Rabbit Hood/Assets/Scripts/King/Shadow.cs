using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shadow : MonoBehaviour
{
    public Transform LeftShadow;
    public Transform RightShadow;
    public Transform King;
    private bool isMove = false;
    private float RightCenterX, RightCenterY, LeftCenterX, LeftCenterY;
    float deg = 0;
    private int isPeriod = 0;
    // Start is called before the first frame update
    void Start()
    {
        LeftShadow.position = new Vector2(King.position.x, King.position.y);
        RightShadow.position = new Vector2(King.position.x, King.position.y);
        RightCenterX = King.position.x + 4f;
        RightCenterY = King.position.y + 3f;
        LeftCenterX = King.position.x - 4f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(RightShadow.position.y);
        if (isMove == false)
        {
            LeftShadow.Translate(new Vector2(-2f*Time.deltaTime, 0));
            RightShadow.Translate(new Vector2(2f*Time.deltaTime, 0));

        }
        if (isMove == false && LeftShadow.position.x <= King.position.x - 4f)
            isMove = true;
        if (isMove)
        {

            deg += 60f*Time.deltaTime;
            if (deg < 360)
            {
                var rad = Mathf.Deg2Rad * (deg);
                var x = 3f * Mathf.Sin(rad);
                var y = 3f * Mathf.Cos(rad);
                RightShadow.position = new Vector2(RightCenterX + x, RightCenterY - y);
                LeftShadow.position = new Vector2(LeftCenterX - x, RightCenterY - y);
            }
            else
            {
                deg = 0; 
            }

        }
    }
}
