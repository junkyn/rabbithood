using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_platform_vertical : MonoBehaviour
{
    float first_location;
    float second_location;
    bool isRight = true;
    public float velocity;
    GameObject first;
    GameObject second;
    private void Start()
    {
        first = GameObject.Find("moving_platform_down");
        second = GameObject.Find("moving_platform_up");

        first_location = first.transform.position.y - 0.2f;
        second_location = second.transform.position.y + 1.5f;
    }
    // Update is called once per frame
    void Update()
    {

        if (isRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, second_location), velocity * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, first_location), velocity * Time.deltaTime);
        }

        if (Mathf.Abs(transform.position.y - second_location) <= 0.2f && isRight)
        {

            isRight = false;
        }
        else if (Mathf.Abs(transform.position.y - first_location) <= 0.2f && !isRight)
        {

            isRight = true;
        }
    }

}
