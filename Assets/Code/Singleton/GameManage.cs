using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage game = null;
    
    public GameObject player;
    public ParticleSystem centralPlayerVFX;
    public Player_Controller pc;
    private int player_death_counter = 0;
    public int level = 1;
    public int score, lives;
    void Awake()
    {
        if(game == null) {
            game = this;
        }else if(game != this) {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        lives = 5;
        score = 0;
    }

    void Update()
    {
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
    }
}
