using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2PerkController : MonoBehaviour
{
    public GameObject spot_1, spot_2, spot_3, spot_4, spot_5;
    public GameObject perk_obj_1, perk_obj_2;
    public int timer = 0, spot_num, perk_choice;
    public bool can_appear_perk = false, perk_alive = false;

    void Start(){can_appear_perk = false;}

    void Update(){
        if (!can_appear_perk){
            timer++;
            if (timer >= 2000) {
                can_appear_perk = true;
                timer = 0;
            }
        }

        if (can_appear_perk && !perk_alive){
            spot_num = Random.Range(1, 6);
            perk_choice = Random.Range(1, 3);
            switch (spot_num){
                case 1:
                    if(perk_choice == 1){
                        Instantiate(perk_obj_1, spot_1.transform.position, Quaternion.identity);
                    }else{
                        Instantiate(perk_obj_2, spot_1.transform.position, Quaternion.identity);
                    }
                    perk_alive = true;
                break;
                case 2:
                    if(perk_choice == 1){
                        Instantiate(perk_obj_1, spot_2.transform.position, Quaternion.identity);
                    }else{
                        Instantiate(perk_obj_2, spot_2.transform.position, Quaternion.identity);
                    }
                    perk_alive = true;
                break;
                case 3:
                    if(perk_choice == 1){
                        Instantiate(perk_obj_1, spot_3.transform.position, Quaternion.identity);
                    }else{
                        Instantiate(perk_obj_2, spot_3.transform.position, Quaternion.identity);
                    }
                    perk_alive = true;
                break;
                case 4:
                    if(perk_choice == 1){
                        Instantiate(perk_obj_1, spot_4.transform.position, Quaternion.identity);
                    }else{
                        Instantiate(perk_obj_2, spot_4.transform.position, Quaternion.identity);
                    }
                    perk_alive = true;
                break;
                case 5:
                    if(perk_choice == 1){
                        Instantiate(perk_obj_1, spot_5.transform.position, Quaternion.identity);
                    }else{
                        Instantiate(perk_obj_2, spot_5.transform.position, Quaternion.identity);
                    }
                    perk_alive = true;
                break;
            }
        }

        if (perk_obj_1 == null){
            can_appear_perk = false;
        }
    }
}
