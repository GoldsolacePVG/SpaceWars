using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public Rigidbody2D bullet_rb;
    private float speed = 10.0f;
    void Start()
    {
        bullet_rb = GetComponent<Rigidbody2D>();
    }

    void MoveForward() {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void Update()
    {
        MoveForward();
    }
}
