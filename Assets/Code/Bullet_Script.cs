using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public Rigidbody2D bullet_rb;
    public Player_Controller pc;
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

    public void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Laser_Enemy")) {
            pc.laser_killed += 1;
            pc.score += 10;
            Debug.Log("Player Laser Killed: " + pc.laser_killed);
            Debug.Log("Player Score: " + pc.score);
            Destroy(this);
        }       
    }
}
