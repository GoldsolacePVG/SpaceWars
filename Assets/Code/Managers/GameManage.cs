using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static GameManage game = null;
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
}
