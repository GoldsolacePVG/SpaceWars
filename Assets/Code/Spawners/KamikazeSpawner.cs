using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeSpawner : MonoBehaviour
{
    public GameObject kamikaze_enemy_prefab;
    private GameObject go;
    private bool is_active = false;
    private int active_count = 0;

    void Update()
    {
        if (!is_active)
        {
            CreateEnemy();
        }

        if (go == null)
        {
            active_count++;
            if (active_count >= 100)
            {
                is_active = false;
                active_count = 0;
            }
        }
    }

    void CreateEnemy() {
        go = Instantiate<GameObject>(kamikaze_enemy_prefab, this.transform.position, Quaternion.identity);
        is_active = true;
    }
}
