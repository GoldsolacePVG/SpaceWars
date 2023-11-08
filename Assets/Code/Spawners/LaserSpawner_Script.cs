using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner_Script : MonoBehaviour
{
    public GameObject laser_enemy_prefab;
    private GameObject go;
    private int active_count = 0;
    private bool is_active = false;
    void Start() {}

    void Update()
    {
        if(!is_active) {
            CreateEnemy();
        }

        if(go == null) {
            active_count++;
            if(active_count >= 200) {
                is_active = false;
                active_count = 0;
            }
        }
    }

    void CreateEnemy() {
        go = Instantiate<GameObject>(laser_enemy_prefab, this.transform.position, Quaternion.identity);
        is_active = true;
    }
}
