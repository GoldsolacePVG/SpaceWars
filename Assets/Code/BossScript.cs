using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject enemy_prefab, bullet_prefab;
    private float speed = 5.0f;
    private int direction = 0, enemy_counter = 0;
    public int phase = 1, health = 1000;
    public bool can_shoot_enemy = true;
    
    void Start(){}

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

    void FireEnemy() {
        Vector3 aux_vector = this.transform.position;
        aux_vector.y = this.transform.position.y - 3;
        
        Instantiate(enemy_prefab, aux_vector, Quaternion.identity);
    }

    void FireBullet() {
        Vector3 aux_vector = this.transform.position;
        aux_vector.y = this.transform.position.y - 1;
        
        Instantiate(bullet_prefab, aux_vector, Quaternion.identity);
    }
    
    void Update(){
        if(this.transform.position.x <= -4.81f) {direction = 1;}
        if(this.transform.position.x >= 4.81f) {direction = 0;}
        Move();

        if (health <= 500){phase = 2;}
        
        if (can_shoot_enemy && phase == 1){
            FireEnemy();
            can_shoot_enemy = false;
        }

        if (can_shoot_enemy && phase == 2){
            FireBullet();
            can_shoot_enemy = false;
        }

        if (!can_shoot_enemy) {
            enemy_counter++;
            if (enemy_counter >= 500) {
                can_shoot_enemy = true;
                enemy_counter = 0;
            }
        }
    }
}
