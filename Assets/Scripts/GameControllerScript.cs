using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public static GameControllerScript instance;

    private int enemyCount = 0;
    public bool isAllSpawnPointWork = true;


    // Start is called before the first frame update
    void Start () {
        instance = this;
    }

    // Update is called once per frame
    void Update () {
        ChangeAllSpawnPointWork ();
    }

    public void increaseEnemyCount () {
        enemyCount += 1;
    }

    void ChangeAllSpawnPointWork () {
        if (enemyCount > 20) {
            isAllSpawnPointWork = false;
        }
    }
}