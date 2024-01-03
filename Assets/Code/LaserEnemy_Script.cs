using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy_Script : MonoBehaviour
{
    public GameObject bullet_prefab;
    public GameObject destructionVFX;
    private float speed = 5.0f;
    private int direction = 0;
    private int hits = 0;
    private int shoot_count = 0;
    private bool can_shoot = false;
    private bool first_time_shooting = false;
    void Start() {
        //spawn = this.transform.position;
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

    void FireToPlayer() {
        Vector3 aux_vector = this.transform.position;
        aux_vector.y = this.transform.position.y - 1;

        GameObject sp = Instantiate<GameObject>(bullet_prefab, aux_vector, Quaternion.identity);
    }

    void Update() {
        if(!first_time_shooting) {
            int start_value = Random.Range(0, 70);
            if(start_value == 1) {
                first_time_shooting = true;
            }
        }
        if(this.transform.position.x <= -6.16f) {direction = 1;}
        if(this.transform.position.x >= 6.16f) {direction = 0;}
        Move();

        if(can_shoot) {
            FireToPlayer();
            can_shoot = false;
        }
    }

    private void FixedUpdate()
    {
        if(first_time_shooting) {
            if(!can_shoot) {
                shoot_count++;
                if(shoot_count >= 40) {
                    can_shoot = true;
                    shoot_count = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player_Controller pc = FindObjectOfType<Player_Controller>();
        if(other.CompareTag("Player")) {
            if(pc != null) {
                Instantiate(destructionVFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if(other.CompareTag("Bullet")) {
            hits += 1;
            if(hits >= 5) {
                pc.AddScore("Laser");
                Instantiate(destructionVFX, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
