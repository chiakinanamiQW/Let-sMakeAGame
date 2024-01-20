using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatForm : MonoBehaviour
{
    public float Speed;
    public float moveduration;
    private float timer;

    void Start()
    {
        timer = moveduration;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Speed = -Speed;
            timer = moveduration;
        }
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}
