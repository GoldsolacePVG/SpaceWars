using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Script : MonoBehaviour
{
    public Transform first_stage, second_stage, third_stage;
    public BombEnemy_Script bs_1, bs_2, bs_3;
    private int path;
    private float speed = 5.0f;
    void Start() {
        path = Random.Range(1, 4);
    }

    void MoveToPath() {
        Transform orientation = first_stage;

        switch(path) {
            case 1:
                orientation = first_stage;
            break;
            case 2:
                orientation = second_stage;
            break;
            case 3:
                orientation = third_stage;
            break;
        }
        transform.position = Vector3.MoveTowards(transform.position, orientation.position, speed * Time.deltaTime);
    }

    void Update() {
        MoveToPath();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") || other.CompareTag("Bullet")) {
            switch (GameManager2.game_2.bomb_enemy_active) {
                case 0:
                    bs_1.can_shoot = true;
                break;
                case 1:
                    bs_2.can_shoot = true;
                break;
                case 2:
                    bs_3.can_shoot = true;
                break;
            }
            Destroy(gameObject);
        }
    }
}
