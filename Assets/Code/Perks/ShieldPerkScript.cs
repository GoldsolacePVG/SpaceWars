using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPerkScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
