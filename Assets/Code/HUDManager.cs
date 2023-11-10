using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Player_Controller pc;
    public Text lives_text;
    public Text score_text;
    private int lives_shown = 3;
    private int score_shown = 0;
    private string score_string;
    void Start() {
        lives_shown = pc.lives - 1;
        score_shown = pc.score;
    }

    void Update() {
        // Lives
        lives_shown = pc.lives - 1;
        lives_text.text = "X" + lives_shown.ToString();

        // Score
        score_shown = pc.score;
        score_text.text = string.Format("{0:0000}", score_shown);
    }
}
