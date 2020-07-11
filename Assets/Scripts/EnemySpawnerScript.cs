using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
    public GameObject enemyPrefab;
    public Transform enemySpawner;

    public GameObject player;

    public float TimeBetweenSpawn = 2f;
    private float m_timeStamp = 0f;

    [SerializeField] bool isSpawnWork = false; // работатет ли точка спавна
    float minSpawnDist = 45f, maxSpanwDist = 150f; //дистанции от игрока в пределах которых включается спавн в точке спавна

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        IsSpawnWork ();
        if (Time.time >= m_timeStamp && isSpawnWork) {
            Spawn ();
            GameControllerScript.instance.increaseEnemyCount ();
            m_timeStamp = Time.time + TimeBetweenSpawn;
        }
    }

    void Spawn () {
        Instantiate (enemyPrefab, enemySpawner.position, enemySpawner.rotation);
    }

    void IsSpawnWork () {
        if (!GameControllerScript.instance.isAllSpawnPointWork) {
            isSpawnWork = false;
            return;
        }

        float distance = Vector3.Distance (player.transform.position, transform.position);

        if (distance > minSpawnDist && distance < maxSpanwDist) {
            isSpawnWork = true;
        } else {
            isSpawnWork = false;
        }
    }
}