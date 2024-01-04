using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkScript : MonoBehaviour
{
    public float rot_speed = 50.0f;

    void Update()
    {
        float rotation_spd = rot_speed * Time.deltaTime;
        
        gameObject.transform.Rotate(Vector3.forward, rotation_spd);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
