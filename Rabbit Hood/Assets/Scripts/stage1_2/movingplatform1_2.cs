using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform1_2 : MonoBehaviour
{
    float first_place;
    public float last_place;
    bool direction = true;
    public float velocity = 0.5f;


    private void Start()
    {
        first_place = this.transform.position.y;
        last_place += first_place;

    }

    void Update()
    {
        if (direction)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, last_place), velocity * Time.deltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, first_place), velocity * Time.deltaTime);

        if (Mathf.Abs(transform.position.y - last_place) <= 0.1f && direction)
            direction = false;
        else if (Mathf.Abs(transform.position.y - first_place) <= 0.1f && !direction)
            direction = true;
    }
}
