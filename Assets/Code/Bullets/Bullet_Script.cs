using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    private BossScript boss;
    private float speed = 10.0f;

    void Start()
    {
        boss = GameObject.Find("boss").GetComponent<BossScript>();
    }

    void MoveForward() {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void Update() {
        MoveForward();

        if(this.transform.position.y >= 20.0f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("LaserEnemy") || other.CompareTag("BombEnemy") ||
           other.CompareTag("KamikazeEnemy") || other.CompareTag("CannonEnemy") ||
           other.CompareTag("Boss") || other.CompareTag("LaserBullet")) {
            if (other.CompareTag("Boss")) {
                boss.health -= 20;
            }
            Destroy(gameObject);
        }
    }
}
