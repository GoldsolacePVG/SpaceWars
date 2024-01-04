using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkScript : MonoBehaviour
{
    public LV1PerkController lv1;
    public LV2PerkController lv2;
    public float rot_speed = 50.0f;

    private void Start()
    {
        if (GameManage.game.level == 1){
            lv1 = GameObject.Find("Main Camera").GetComponent<LV1PerkController>();
        }else if (GameManage.game.level == 2){
            lv2 = GameObject.Find("Main Camera").GetComponent<LV2PerkController>();
        }
    }

    void Update()
    {
        //lv1 = GameObject.Find("Main Camera").GetComponent<LV1PerkController>();
        //lv2 = GameObject.Find("Main Camera").GetComponent<LV2PerkController>();
        float rotation_spd = rot_speed * Time.deltaTime;
        
        gameObject.transform.Rotate(Vector3.forward, rotation_spd);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            if (GameManage.game.level == 1){
                lv1.can_appear_perk = false;
            }else if (GameManage.game.level == 2){
                lv2.can_appear_perk = false;
            }
            Destroy(gameObject);
        } 
    }
}
