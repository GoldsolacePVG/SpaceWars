using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV1PerkController : MonoBehaviour
{
    public GameObject spot_1, spot_2, spot_3, spot_4, spot_5;
    public GameObject perk_obj;
    public int timer = 0, spot_num;
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
            switch (spot_num){
                case 1:
                    Instantiate(perk_obj, spot_1.transform.position, Quaternion.identity);
                    perk_alive = true;
                break;
                case 2:
                    Instantiate(perk_obj, spot_2.transform.position, Quaternion.identity);
                    perk_alive = true;
                break;
                case 3:
                    Instantiate(perk_obj, spot_3.transform.position, Quaternion.identity);
                    perk_alive = true;
                break;
                case 4:
                    Instantiate(perk_obj, spot_4.transform.position, Quaternion.identity);
                    perk_alive = true;
                break;
                case 5:
                    Instantiate(perk_obj, spot_5.transform.position, Quaternion.identity);
                    perk_alive = true;
                break;
            }
        }

        if (perk_obj == null){
            can_appear_perk = false;
        }
    }
}
