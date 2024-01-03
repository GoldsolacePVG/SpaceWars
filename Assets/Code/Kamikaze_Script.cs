using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze_Script : MonoBehaviour
{
    public GameObject player;
    private float speed = 5.0f;
    private int direction = 0;
    private int hits = 0;
    private bool is_following_player = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        is_following_player = false;
    }

    void Move() {
        switch(direction){
            case 0:
                this.transform.position += Vector3.left * speed * Time.deltaTime;
            break;
            case 1:
                this.transform.position += Vector3.right * speed * Time.deltaTime;
            break;
        }
    }

    void ToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
    
    void Update()
    {
        if(this.transform.position.x >= player.transform.position.x - 1.0f && this.transform.position.x <= player.transform.position.x + 1.0f){is_following_player = true;}
        if(this.transform.position.x <= -6.16f) {direction = 1;}
        if(this.transform.position.x >= 6.16f) {direction = 0;}
        if (!is_following_player){
            Move();
        }else{  
            ToPlayer();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        Player_Controller pc = FindObjectOfType<Player_Controller>();
        if(other.CompareTag("Player")) {if(pc != null) {Destroy(gameObject);}}
        if(other.CompareTag("Bullet")) {
            hits += 1;
            if(hits >= 2) {
                pc.AddScore("Kamikaze");
                Destroy(gameObject);
            }
        }
    }
}
