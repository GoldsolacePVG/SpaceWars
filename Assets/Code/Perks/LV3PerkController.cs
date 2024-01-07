using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV3PerkController : MonoBehaviour
{
    public GameObject spot_1, spot_2;
    public GameObject perk_obj_1, perk_obj_2;
    public int timer_1 = 0, timer_2 = 0, spot_num;
    public bool can_appear_perk_1 = false, perk_alive_1 = false;
    public bool can_appear_perk_2 = false, perk_alive_2 = false;

    void Start(){can_appear_perk_1 = false;}

    void Update(){
        //TIMER
        
        //Shield
        if (!can_appear_perk_1){
            timer_1++;
            if (timer_1 >= 500) {
                can_appear_perk_1 = true;
                timer_1 = 0;
            }
        }
        //Bullet
        if (!can_appear_perk_2){
            timer_2++;
            if (timer_2 >= 500) {
                can_appear_perk_2 = true;
                timer_2 = 0;
            }
        }
        
        ///////////////////////////////////////////////////////////////

        if (can_appear_perk_1 && !perk_alive_1) {
            Instantiate(perk_obj_1, spot_1.transform.position, Quaternion.identity);
            perk_alive_1 = true;
        }

        if (can_appear_perk_2 && !perk_alive_2) {
            Instantiate(perk_obj_2, spot_2.transform.position, Quaternion.identity);
            perk_alive_2 = true;
        }
    }
}
