using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject menu_1, menu_2;
    public void SceneChange(int sceneValue) {
        SceneManager.LoadScene(sceneValue);
    }

    public void ActivateImg()
    {
        menu_1.SetActive(false);
        menu_2.SetActive(true);
    }

    public void InverseImg()
    {
        menu_1.SetActive(true);
        menu_2.SetActive(false);
    }

    public void InitChange(int sceneValue)
    {
        GameManage.game.lives = 5;
        GameManage.game.score = 0;
        SceneManager.LoadScene(sceneValue);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
