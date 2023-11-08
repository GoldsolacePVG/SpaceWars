using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy_Script : MonoBehaviour
{
    private float speed = 5.0f;
    private int direction = 0;
    private int hits = 0;
    void Start() {
        
    }

    void Move() {
        switch (direction) {
            case 0:
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            break;
            case 1:
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            break;
        }
    }

    void Update() {
        if(this.transform.position.x < -6.16f) {direction = 1;}
        if(this.transform.position.x >= 6.16f) {direction = 0;}
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player_Controller pc = FindObjectOfType<Player_Controller>();
        if(other.CompareTag("Player")) {
            if(pc != null) {
                Destroy(gameObject);
            }
        }
        if(other.CompareTag("Bullet")) {
            hits += 1;
            if(hits >= 5) {
                pc.AddScore("Laser");
                Destroy(gameObject);
            }
        }
    }
}
