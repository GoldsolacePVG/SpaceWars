using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public GameObject bullet_prefab;
    private float speed = 10.0f;
    public int score = 0;
    public int laser_killed = 0;
    public int bomb_killed = 0;
    public int lives = 3;
    private int shoot_count = 0;
    private bool can_shoot = true;

    void Start() {}

    void Fire() {
        GameObject sp = Instantiate<GameObject>(bullet_prefab, this.transform.position, Quaternion.identity);
    }

    public void AddScore(string enemy) {
        switch (enemy) {
            case "Laser":
                score += 10;
                laser_killed++;
            break;
            case "Bomb":
                score += 20;
                bomb_killed++;
            break;
        }
        Debug.Log("Player Score: " + score);
    }

    void Update()
    {
        // PLAYER INPUTS
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -6.23f){this.transform.position += Vector3.left * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 6.24f){this.transform.position += Vector3.right * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && this.transform.position.y < 0.0f) {this.transform.position += Vector3.up * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && this.transform.position.y > -5.97f) {this.transform.position += Vector3.down * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.Space) && can_shoot) {
            Fire();
            can_shoot = false;
        }

        if(!can_shoot) {
            shoot_count++;
            if(shoot_count >= 20) {
                can_shoot = true;
                shoot_count = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LaserEnemy") || other.CompareTag("BombEnemy")) {
            lives--;
        }
    }
}
