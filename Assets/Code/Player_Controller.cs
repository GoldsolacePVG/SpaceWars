using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D player_rigid;
    public float lateral_speed = 5.0f;
    void Start()
    {
        player_rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            this.transform.position += Vector3.left * lateral_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            this.transform.position += Vector3.right * lateral_speed * Time.deltaTime;
        }
    }
}
