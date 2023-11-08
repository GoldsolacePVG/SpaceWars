using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage game = null;

    public GameObject bomb_enemy1, bomb_enemy2, bomb_enemy3;
    private bool bomb1_alive = true, bomb2_alive = true;
    void Awake()
    {
        if(game == null) {
            game = this;
        }else if(game != this) {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(bomb1_alive) {
            if(bomb_enemy1 == null) {
                bomb_enemy2.SetActive(true);
                bomb1_alive = false;
            }
        }
        if(bomb2_alive) {
            if(bomb_enemy2 == null) {
                bomb_enemy3.SetActive(true);
                bomb2_alive = false;
            }
        }
    }
}
