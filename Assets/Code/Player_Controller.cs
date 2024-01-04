using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public GameObject bullet_prefab, destructionVFX, shield_obj;
    public GameObject lateralR, lateralL;
    public ParticleSystem centralVFX, lateralRVFX, lateralLVFX;
    public AudioSource fire_audio;
    private Vector3 spawn;
    private float speed = 10.0f;
    public int laser_killed = 0, bomb_killed = 0, kamikaze_killed = 0;
    private int shoot_count = 0, shield_hit = 0, multi_bullet_count = 0;
    private bool can_shoot = true;
    public bool dead = false, shield_on = false, multi_bullet_on = false;

    void Start() {
        spawn = transform.position;
    }

    public void SpawnPlayer() {
        this.transform.position = spawn;
    }

    void Fire() {
        centralVFX.Play();
        GameObject sp = Instantiate<GameObject>(bullet_prefab, this.transform.position, Quaternion.identity);
        if (multi_bullet_on){
            lateralLVFX.Play();
            GameObject sp1 = Instantiate<GameObject>(bullet_prefab, lateralL.transform.position, Quaternion.identity);
            lateralRVFX.Play();
            GameObject sp2 = Instantiate<GameObject>(bullet_prefab, lateralR.transform.position, Quaternion.identity);
        }
        fire_audio.Play();
    }

    public void AddScore(string enemy) {
        switch (enemy) {
            case "Laser":
                GameManage.game.score += 10;
                laser_killed++;
            break;
            case "Bomb":
                GameManage.game.score += 20;
                bomb_killed++;
            break;
            case "Kamikaze":
                GameManage.game.score += 5;
                kamikaze_killed++;
            break;
        }
    }

    public void Destruction() {
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        dead = true;
        GameManage.game.lives--;
    }

    void Update()
    {
        // PLAYER INPUTS
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && this.transform.position.x > -6.23f){this.transform.position += Vector3.left * speed * Time.deltaTime;}
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && this.transform.position.x < 6.24f){this.transform.position += Vector3.right * speed * Time.deltaTime;}
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && this.transform.position.y < 0.0f) {this.transform.position += Vector3.up * speed * Time.deltaTime;}
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && this.transform.position.y > -5.97f) {this.transform.position += Vector3.down * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.Space) && can_shoot) {
            Fire();
            can_shoot = false;
        }

        if (shield_on){shield_obj.SetActive(true);}else{shield_obj.SetActive(false);}
        if (shield_hit >= 4){shield_on = false;}

        if (multi_bullet_on){
            multi_bullet_count++;
            if (multi_bullet_count >= 500){
                multi_bullet_on = false;
                multi_bullet_count = 0;
            }
        }
    }

    private void FixedUpdate() 
    {
        if(!can_shoot) {
            shoot_count++;
            //Old Value 25
            if(shoot_count >= 10) {
                can_shoot = true;
                shoot_count = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LaserEnemy") || other.CompareTag("BombEnemy") || 
            other.CompareTag("LaserBullet") || other.CompareTag("BombBullet") ||
            other.CompareTag("KamikazeEnemy") && !shield_on) {
            Destruction();
        }else if (other.CompareTag("LaserEnemy") || other.CompareTag("BombEnemy") ||
                  other.CompareTag("LaserBullet") || other.CompareTag("BombBullet") ||
                  other.CompareTag("KamikazeEnemy") && shield_on){
            shield_hit++;
        }

        if (other.CompareTag("ShieldPerk")){
            shield_on = true;
        }

        if (other.CompareTag("BulletPerk")){
            multi_bullet_on = true;
        }
    }
}
