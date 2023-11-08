using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Player_Controller pc;
    public Text lives_text;
    public int lives_shown = 3;
    void Start() {
        lives_shown = pc.lives;
    }

    void Update() {
        lives_shown = pc.lives - 1;
        lives_text.text = "X" + lives_shown.ToString();
    }
}
