using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject enemy_prefab, bullet_prefab;
    public GameObject spw_1, spw_2, spw_3, spw_4;
    private float speed = 5.0f;
    private int direction = 0, enemy_counter = 0;
    public int phase = 1, health = 1000;
    private int spawner;
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
        spawner = Random.Range(1, 5);
        switch (spawner){
            case 1:
                Instantiate(enemy_prefab, spw_1.transform.position, Quaternion.identity);
            break;
            case 2:
                Instantiate(enemy_prefab, spw_2.transform.position, Quaternion.identity);
            break;
            case 3:
                Instantiate(enemy_prefab, spw_3.transform.position, Quaternion.identity);
            break;
            case 4:
                Instantiate(enemy_prefab, spw_4.transform.position, Quaternion.identity);
            break;
        }
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
            if (enemy_counter >= 200 && phase == 2) {
                can_shoot_enemy = true;
                enemy_counter = 0;
            }
            if (enemy_counter >= 350) {
                can_shoot_enemy = true;
                enemy_counter = 0;
            }
        }
    }
}
