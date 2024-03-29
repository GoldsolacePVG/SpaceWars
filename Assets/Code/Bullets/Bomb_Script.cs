using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Script : MonoBehaviour
{
    public LV2Manager manager;
    public Transform first_stage, second_stage, third_stage, waiter;
    public BombEnemy_Script bs_1, bs_2, bs_3;
    public GameObject destructionVFX;
    private GameObject enemy;
    private int path, counter = 0;
    private float speed = 5.0f;
    public bool moving = true;
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
        enemy = GameObject.Find("bomb_enemy");
        if (moving) {
            MoveToPath();
        }

        if (!moving) {
            counter++;
            if (counter > 100) {
                path = Random.Range(1, 4);
                moving = true;
                transform.position = enemy.transform.position;
                counter = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") || other.CompareTag("Bullet")) {
            switch (manager.bomb_enemy_active) {
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
            Instantiate(destructionVFX, transform.position, Quaternion.identity);
            transform.position = waiter.position;
            moving = false;
        }
    }
}
