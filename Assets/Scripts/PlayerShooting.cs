﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject BulletPrefab;
    public Transform BulletSpawn;

    public float TimeBetweenShots = 0.3333f;
    private float m_timeStamp = 0f;

    private bool isPlayerShoot = false;

    void FixedUpdate () {
        isPlayerShoot = GameControllerScript.instance.isReadyToShoot;
        if ((Time.time >= m_timeStamp) && (isPlayerShoot)) {
            Fire ();
            m_timeStamp = Time.time + TimeBetweenShots;
        }
    }

    void Fire () {
        var bullet = (GameObject) Instantiate (BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);

        // add velocity to the bullet
        bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 50;

        // Destroy the bullet after some seconds
        Destroy (bullet, 2.0f);
    }

}