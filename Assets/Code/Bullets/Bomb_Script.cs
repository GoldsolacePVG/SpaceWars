using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Script : MonoBehaviour
{
    public Transform first_stage, second_stage, third_stage;
    private int path;
    private float speed = 5.0f;
    void Start() {
        path = Random.Range(1, 4);
    }

    void MoveToPath() {
        Transform orientation = first_stage;

        switch(path) {
            case 1:
                orientation = first_stage;
            break;
            case 2:
                orientation = second_stage;
            break;
            case 3:
                orientation = third_stage;
            break;
        }
        transform.position = Vector3.MoveTowards(transform.position, orientation.position, speed * Time.deltaTime);
    }

    void Update() {
        MoveToPath();
    }
}
