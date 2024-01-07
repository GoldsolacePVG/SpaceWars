using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public GameObject enemy_prefab, bullet_prefab, right_bullet, left_bullet;
    public GameObject spw_1, spw_2, spw_3, spw_4;
    public GameObject ls_1, ls_2, ls_3, ls_4;
    private float speed = 5.0f;
    private int direction = 0, enemy_counter = 0;
    private int ind_1, ind_2, ind_3, ind_4;
    public int phase = 1, health = 1000;
    private int spawner;
    public bool can_shoot_enemy = true;
    public Vector3 rotacionEuler1 = new Vector3(0f, 0f, 90f);
    public Vector3 rotacionEuler2 = new Vector3(0f, 0f, -90f);
    
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
        Vector3 aux_vec_2 = aux_vector, aux_vec_3 = aux_vector;
        aux_vec_2.x = aux_vector.x - 1;
        aux_vec_3.x = aux_vector.x + 1;
        
        Instantiate(bullet_prefab, aux_vector, Quaternion.identity);
        Instantiate(bullet_prefab, aux_vec_2, Quaternion.identity);
        Instantiate(bullet_prefab, aux_vec_3, Quaternion.identity);
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

        if (phase == 2) {
            ind_1 = Random.Range(1, 101);
            ind_2 = Random.Range(1, 101);
            ind_3 = Random.Range(1, 101);
            ind_4 = Random.Range(1, 101);

            if (ind_1 == 1) {
                Instantiate(left_bullet, ls_1.transform.position, Quaternion.Euler(rotacionEuler2));
            }
            if (ind_2 == 1) {
                Instantiate(left_bullet, ls_2.transform.position, Quaternion.Euler(rotacionEuler2));
            }
            if (ind_3 == 1) {
                Instantiate(right_bullet, ls_3.transform.position, Quaternion.Euler(rotacionEuler1));
            }
            if (ind_4 == 1) {
                Instantiate(right_bullet, ls_4.transform.position, Quaternion.Euler(rotacionEuler1));
            }
        }

        if (health <= 0) {
            SceneManager.LoadScene(5);
        }
    }
}
