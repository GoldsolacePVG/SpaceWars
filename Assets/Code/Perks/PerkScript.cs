using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkScript : MonoBehaviour
{
    public LV1PerkController lv1;
    public LV2PerkController lv2;
    public LV3PerkController lv3;
    public float rot_speed = 50.0f;

    private void Start()
    {
        if (GameManage.game.level == 1){
            lv1 = GameObject.Find("Main Camera").GetComponent<LV1PerkController>();
        }else if (GameManage.game.level == 2){
            lv2 = GameObject.Find("Main Camera").GetComponent<LV2PerkController>();
        }else if (GameManage.game.level == 3){
            lv3 = GameObject.Find("Main Camera").GetComponent<LV3PerkController>();
        }
    }

    void Update()
    {
        float rotation_spd = rot_speed * Time.deltaTime;
        
        gameObject.transform.Rotate(Vector3.forward, rotation_spd);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            if (GameManage.game.level == 1){
                lv1.can_appear_perk = false;
            }else if (GameManage.game.level == 2){
                lv2.can_appear_perk = false;
            }else if (GameManage.game.level == 3) {
                if (this.CompareTag("ShieldPerk")) {
                    lv3.can_appear_perk_1 = false;
                } 
                if (this.CompareTag("BulletPerk")) {
                    lv3.can_appear_perk_2 = false;
                } 
            }
            Destroy(gameObject);
        } 
    }
}
