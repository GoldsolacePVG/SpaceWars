using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Script : MonoBehaviour
{
    private float speed = 10.0f;
    void Start() {}

    void MoveForward() {
        this.transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void Update() {
        MoveForward();
        if (this.transform.position.y >= -20.0f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") || other.CompareTag("Bullet")) {
            Destroy(gameObject);
        }
    }
}
