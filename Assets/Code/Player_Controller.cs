using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D player_rigid;
    public Sprite bullet_sprite;
    private float speed = 10.0f;

    void Start()
    {
        player_rigid = GetComponent<Rigidbody2D>();
    }

    void Fire() {
        Sprite sp = Instantiate<Sprite>(bullet_sprite, this.transform.position, Quaternion.identity);
    }

    void Update()
    {
        // PLAYER INPUTS
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -6.23){this.transform.position += Vector3.left * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 6.24){this.transform.position += Vector3.right * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {this.transform.position += Vector3.up * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && this.transform.position.y > -5.99){this.transform.position += Vector3.down * speed * Time.deltaTime;}
        if (Input.GetKey(KeyCode.Space)) {
            Fire();
        }
    }
}
