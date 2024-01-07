using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralLaserScript : MonoBehaviour
{
    private float speed = 15.0f;

    void MoveForward() {
        if (this.CompareTag("RightLaser")) {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (this.CompareTag("LeftLaser")) {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    void Update() {
        MoveForward();
        if (this.transform.position.x <= -20.0f || this.transform.position.x >= 20.0f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") || other.CompareTag("Bullet")) {
            Destroy(gameObject);
        }
    }
}