using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy_Script : MonoBehaviour
{
    public Transform first_stage, second_stage, third_stage,
                     fourth_stage, fifth_stage;
    private int path = 0, index_forward = 0, index_backward = 0, hits = 0;
    private float speed = 5.0f;

    void Start() {}

    void MoveForward() {
        Transform orientation = second_stage;

        switch (index_forward) {
            case 0:
                orientation = second_stage;
            break;
            case 1:
                orientation = third_stage;
            break;
            case 2:
                orientation = fourth_stage;
            break;
            case 3:
                orientation = fifth_stage;
            break;
        }
        transform.position = Vector3.MoveTowards(transform.position, orientation.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, orientation.position) < 0.1f) {
            index_forward += 1;
            if(orientation == fifth_stage) {
                index_backward = 0;
                path = 1;
            }
        }
    }

    void MoveBackward() {
        Transform orientation = fourth_stage;

        switch (index_backward) {
            case 0:
                orientation = fourth_stage;
            break;
            case 1:
                orientation = third_stage;
            break;
            case 2:
                orientation = second_stage;
            break;
            case 3:
                orientation = first_stage;
            break;
        }
        transform.position = Vector3.MoveTowards(transform.position, orientation.position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, orientation.position) < 0.1f) {
            index_backward += 1;
            if(orientation == first_stage) {
                index_forward = 0;
                path = 0;
            }
        }
    }

    void FollowPath() {
        switch (path) {
            case 0:
                MoveForward();
            break;
            case 1:
                MoveBackward();
            break;
        }
    }

    void Update() {
        FollowPath();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player_Controller pc = FindObjectOfType<Player_Controller>();
        if(other.CompareTag("Player")) {
            if(pc != null) {
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Bullet")) {
            hits += 1;
            if(hits >= 3) {
                pc.AddScore("Bomb");
                Destroy(gameObject);
            }
        }
    }
}
