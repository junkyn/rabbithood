using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class moving_platform : MonoBehaviour
{
    float first_location = 0.6f;
    float second_location = 9.5f;
    bool isRight = true;
    public float velocity;
    // Update is called once per frame
    void Update()
    {

        if (isRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(second_location, transform.position.y), velocity * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(first_location, transform.position.y), velocity * Time.deltaTime);
        }

        if(Mathf.Abs(transform.position.x - second_location) <= 0.2f && isRight)
        {
            isRight = false;
        }
        else if(Mathf.Abs(transform.position.x - first_location) <= 0.2f && !isRight)
        {
            isRight = true;
        }
        
    }
}
