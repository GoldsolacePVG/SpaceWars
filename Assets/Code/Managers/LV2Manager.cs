using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV2Manager : MonoBehaviour
{
    public GameObject bomb_enemy1, bomb_enemy2, bomb_enemy3;
    public GameObject laser_spawn1, laser_spawn2;
    public GameObject player;
    public ParticleSystem centralPlayerVFX;
    public Player_Controller pc;
    private int player_death_counter = 0;
    public int bomb_enemy_active = 0;
    public int level = 1;
    private bool bomb1_alive = true, bomb2_alive = true;

    void Update()
    {
        //Bomb Spawn
        if(bomb1_alive) {
            if(bomb_enemy1 == null) {
                bomb_enemy2.SetActive(true);
                bomb_enemy_active = 1;
                bomb1_alive = false;
            }
        }
        if(bomb2_alive) {
            if(bomb_enemy2 == null) {
                bomb_enemy3.SetActive(true);
                bomb_enemy_active = 2;
                bomb2_alive = false;
            }
        }

        //Laser Spawn
        if(pc.laser_killed >= 4) {
            Destroy(laser_spawn1);
            Destroy(laser_spawn2);
        }

        //Player Death
        if (pc.dead) {
            player.SetActive(false);
            player_death_counter++;
            if(player_death_counter >= 100) {
                player.SetActive(true);
                centralPlayerVFX.Stop();
                pc.SpawnPlayer();
                pc.dead = false;
                player_death_counter = 0;
            }
        }

        if (pc.laser_killed >= 4 && pc.bomb_killed >= 3)
        {
            SceneManager.LoadScene(4);
        }
    }
}