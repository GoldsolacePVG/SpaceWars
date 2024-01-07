using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LV1Manager : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem centralPlayerVFX;
    public Player_Controller pc;
    private int player_death_counter = 0;
    
    void Update()
    {
        if (GameManage.game.score >= 300 && GameManage.game.level == 1) {
            SceneManager.LoadScene(4);
        }
        
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
