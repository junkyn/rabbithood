using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class approach : MonoBehaviour
{
    public float velocity;
    public float destin;

    private void Start()
    {
        destin -= transform.position.y;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, destin), velocity * Time.deltaTime);  
    }
}
